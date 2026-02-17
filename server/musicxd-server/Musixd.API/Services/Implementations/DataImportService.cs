using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musicxd.API.Services.Interfaces;
using Musicxd.Domain.Entities;
using Musicxd.Infrastructure.Data;
using System.Globalization;

namespace Musicxd.API.Services.Implementations
{

    public class DataImportService : IDataImportService
    {
        private readonly DataContext _context;

        public DataImportService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MapDatatoEntity()
        {
            var filePath = Path.Combine("..", "Musicxd.Infrastructure", "Data", "albumlist.csv");
            if (!File.Exists(filePath))
                return new NotFoundObjectResult("CSV file not found.");

            var albums = new List<Album>();
            var artistsDict = new Dictionary<string, Artist>(StringComparer.OrdinalIgnoreCase);
            var genresDict = new Dictionary<string, Genre>(StringComparer.OrdinalIgnoreCase);

            using (var reader = new StreamReader(filePath))
            {
                string? line;
                bool isFirst = true;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (isFirst) { isFirst = false; continue; } // skip header

                    var parts = SplitCsvLine(line);
                    if (parts.Length < 5) continue;

                    var year = int.TryParse(parts[1], out var y) ? y : 0;
                    var albumName = string.IsNullOrWhiteSpace(parts[2]) ? null : parts[2].Trim();
                    var artistName = string.IsNullOrWhiteSpace(parts[3]) ? null : parts[3].Trim();
                    var genreNames = string.IsNullOrWhiteSpace(parts[4])
                        ? Array.Empty<string>()
                        : parts[4].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    // ARTIST
                    if (!string.IsNullOrEmpty(artistName) && !artistsDict.TryGetValue(artistName, out var artist))
                    {
                        artist = await _context.Artists.FirstOrDefaultAsync(a => a.Name == artistName)
                            ?? new Artist { Name = artistName };
                        if (artist.ArtistId == 0)
                            _context.Artists.Add(artist);
                        artistsDict[artistName] = artist;
                    }

                    // GENRES
                    var albumGenres = new List<AlbumGenre>();
                    foreach (var genreName in genreNames)
                    {
                        if (string.IsNullOrWhiteSpace(genreName)) continue;
                        if (!genresDict.TryGetValue(genreName, out var genre))
                        {
                            genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreName == genreName)
                                ?? new Genre { GenreName = genreName };
                            if (genre.GenreId == 0)
                                _context.Genres.Add(genre);
                            genresDict[genreName] = genre;
                        }
                        albumGenres.Add(new AlbumGenre { Genre = genre });
                    }

                    // ALBUM
                    Album? album = null;
                    if (!string.IsNullOrEmpty(albumName))
                    {
                        album = await _context.Albums
                            .Include(a => a.AlbumArtists)
                            .Include(a => a.AlbumGenres)
                            .FirstOrDefaultAsync(a => a.AlbumName == albumName && a.ReleaseDate != null && a.ReleaseDate.Value.Year == year);

                        if (album == null)
                        {
                            album = new Album
                            {
                                AlbumName = albumName,
                                ReleaseDate = year > 0 ? new DateTime(year, 1, 1) : null,
                                AlbumArtists = new List<AlbumArtist>(),
                                AlbumGenres = new List<AlbumGenre>()
                            };
                            _context.Albums.Add(album);
                        }

                        // Add artist to album
                        if (!string.IsNullOrEmpty(artistName) && !album.AlbumArtists.Any(aa => aa.Artist?.Name == artistName))
                            album.AlbumArtists.Add(new AlbumArtist { Artist = artistsDict[artistName] });

                        // Add genres to album
                        foreach (var ag in albumGenres)
                        {
                            if (!album.AlbumGenres.Any(x => x.Genre?.GenreName == ag.Genre.GenreName))
                                album.AlbumGenres.Add(new AlbumGenre { Genre = ag.Genre });
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return new OkObjectResult("Import completed successfully.");
        }

        // Simple CSV parser for this context
        private static string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var value = "";
            foreach (var c in line)
            {
                if (c == '"') inQuotes = !inQuotes;
                else if (c == ',' && !inQuotes)
                {
                    result.Add(value);
                    value = "";
                }
                else value += c;
            }
            result.Add(value);
            return result.ToArray();
        }
    }
}
