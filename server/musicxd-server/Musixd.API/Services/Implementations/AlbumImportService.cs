//using Microsoft.EntityFrameworkCore;
//using Musicxd.API.DTOs;
//using Musicxd.API.Services.Interfaces;
//using Musicxd.Domain.Entities;
//using Musicxd.Infrastructure.Data;
//using OfficeOpenXml;
//using System.ComponentModel;

//namespace Musicxd.API.Services.Implementations
//{

//    public class AlbumImportService : IAlbumImportService
//    {
//        private readonly DataContext _context;

//        public AlbumImportService(DataContext context)
//        {
//            _context = context;
//        }

//        public async Task<ImportResult> ImportAlbumsFromExcelAsync(string filePath)
//        {
//            var result = new ImportResult();

//            try
//            {
//                var fileInfo = new FileInfo(filePath);
//                using var stream = fileInfo.OpenRead();
//                result = await ImportAlbumsFromExcelStreamAsync(stream);
//            }
//            catch (Exception ex)
//            {
//                result.Success = false;
//                result.Message = $"Error reading file: {ex.Message}";
//                result.Errors.Add(ex.Message);
//            }

//            return result;
//        }

//        public async Task<ImportResult> ImportAlbumsFromExcelStreamAsync(Stream stream) // Changed to public
//        {
//            var result = new ImportResult
//            {
//                Success = true,
//                Errors = new List<string>()
//            };

//            try
//            {
//                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

//                using var package = new ExcelPackage(stream);
//                var worksheet = package.Workbook.Worksheets[0];

//                // Read all data from Excel
//                var albumDtos = ReadExcelData(worksheet);

//                if (albumDtos.Count == 0)
//                {
//                    result.Message = "No valid data found in Excel file.";
//                    return result;
//                }

//                // Process the data and populate all tables
//                result = await ImportAlbumsAsync(albumDtos);
//            }
//            catch (Exception ex)
//            {
//                result.Success = false;
//                result.Message = $"Error processing Excel file: {ex.Message}";
//                result.Errors.Add(ex.Message);
//            }

//            return result;
//        }

//        private List<AlbumImportDto> ReadExcelData(ExcelWorksheet worksheet)
//        {
//            var albumDtos = new List<AlbumImportDto>();
//            var rowCount = worksheet.Dimension.Rows;

//            // Assuming Excel structure: Column 1=Number, Column 2=Year, Column 3=Album, Column 4=Artist, Column 5=Genre
//            // Or adjust based on your actual Excel structure
//            for (int row = 2; row <= rowCount; row++)
//            {
//                try
//                {
//                    var albumDto = new AlbumImportDto
//                    {
//                        Number = worksheet.Cells[row, 1].GetValue<int>(),
//                        Year = worksheet.Cells[row, 2].GetValue<int>(),
//                        Album = worksheet.Cells[row, 3].GetValue<string>()?.Trim() ?? string.Empty,
//                        Artist = worksheet.Cells[row, 4].GetValue<string>()?.Trim() ?? string.Empty,
//                        Genre = worksheet.Cells[row, 5].GetValue<string>()?.Trim() ?? string.Empty,
//                    };

//                    if (!string.IsNullOrEmpty(albumDto.Album) && !string.IsNullOrEmpty(albumDto.Artist) && !string.IsNullOrEmpty(albumDto.Genre))
//                    {
//                        albumDtos.Add(albumDto);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error processing row {row}: {ex.Message}");
//                }
//            }

//            return albumDtos;
//        }

//        private async Task<ImportResult> ImportAlbumsAsync(List<AlbumImportDto> albumDtos)
//        {
//            var result = new ImportResult { Success = true };

//            using var transaction = await _context.Database.BeginTransactionAsync();

//            try
//            {
//                // First, ensure we have a default studio (required for Album entity)
//                var defaultStudio = await GetOrCreateDefaultStudioAsync();

//                foreach (var dto in albumDtos)
//                {
//                    try
//                    {
//                        await ProcessAlbumAsync(dto, defaultStudio);
//                        result.ImportedCount++;
//                    }
//                    catch (Exception ex)
//                    {
//                        result.SkippedCount++;
//                        result.Errors.Add($"Error importing album '{dto.Album}' by '{dto.Artist}': {ex.Message}");
//                    }
//                }

//                await _context.SaveChangesAsync();
//                await transaction.CommitAsync();

//                result.Message = $"Import completed. {result.ImportedCount} albums imported, {result.SkippedCount} skipped.";
//            }
//            catch (Exception ex)
//            {
//                await transaction.RollbackAsync();
//                result.Success = false;
//                result.Message = $"Import failed: {ex.Message}";
//                result.Errors.Add(ex.Message);
//            }

//            return result;
//        }

//        private async Task ProcessAlbumAsync(AlbumImportDto dto, Studio defaultStudio)
//        {
//            // Check if album already exists
//            var existingAlbum = await _context.Albums
//                .Include(a => a.Artists)
//                .Include(a => a.Genres)
//                .FirstOrDefaultAsync(a => a.AlbumName.ToLower() == dto.Album.ToLower());

//            if (existingAlbum != null)
//            {
//                // Album exists, ensure relationships are created
//                await EnsureAlbumRelationships(existingAlbum, dto);
//                return;
//            }

//            // Get or create artist
//            var artist = await GetOrCreateArtistAsync(dto.Artist);

//            // Get or create genre
//            var genre = await GetOrCreateGenreAsync(dto.Genre);

//            // Get or create release date
//            var releaseDate = await GetOrCreateDateAsync(dto.Year);

//            // Create new album
//            var album = new Album
//            {
//                AlbumName = dto.Album,
//                ReleaseDateId = releaseDate.DateId,
//                CountryName = "Unknown", // Default value, can be enhanced later
//                StudioId = defaultStudio.StudioId,
//                Duration = TimeSpan.Zero, // Default value, can be enhanced later
//                AlbumDescription = $"Album by {dto.Artist} in {dto.Genre} genre", // Default description
//                Artists = new List<Artist> { artist },
//                Genres = new List<Genre> { genre }
//            };

//            _context.Albums.Add(album);
//        }

//        private async Task EnsureAlbumRelationships(Album album, AlbumImportDto dto)
//        {
//            // Ensure artist relationship exists
//            var artist = await GetOrCreateArtistAsync(dto.Artist);
//            if (!album.Artists.Any(a => a.ArtistId == artist.ArtistId))
//            {
//                album.Artists.Add(artist);
//            }

//            // Ensure genre relationship exists
//            var genre = await GetOrCreateGenreAsync(dto.Genre);
//            if (!album.Genres.Any(g => g.GenreId == genre.GenreId))
//            {
//                album.Genres.Add(genre);
//            }
//        }

//        private async Task<Artist> GetOrCreateArtistAsync(string artistName)
//        {
//            if (string.IsNullOrWhiteSpace(artistName))
//                throw new ArgumentException("Artist name cannot be empty");

//            var artist = await _context.Artists
//                .FirstOrDefaultAsync(a => a.Name.ToLower() == artistName.ToLower());

//            if (artist == null)
//            {
//                artist = new Artist
//                {
//                    Name = artistName,
//                    Bio = $"Biography for {artistName}" // Default bio
//                };
//                _context.Artists.Add(artist);
//                await _context.SaveChangesAsync(); // Save to get the ID
//            }

//            return artist;
//        }

//        private async Task<Genre> GetOrCreateGenreAsync(string genreName)
//        {
//            if (string.IsNullOrWhiteSpace(genreName))
//                throw new ArgumentException("Genre name cannot be empty");

//            var genre = await _context.Genres
//                .FirstOrDefaultAsync(g => g.GenreName.ToLower() == genreName.ToLower());

//            if (genre == null)
//            {
//                genre = new Genre { GenreName = genreName };
//                _context.Genres.Add(genre);
//                await _context.SaveChangesAsync(); // Save to get the ID
//            }

//            return genre;
//        }

//        private async Task<Date> GetOrCreateDateAsync(int year)
//        {
//            var date = await _context.Dates
//                .FirstOrDefaultAsync(d => d.Year == year && d.Month == 1 && d.Day == 1);

//            if (date == null)
//            {
//                var dateValue = new DateTime(year, 1, 1);
//                date = new Date
//                {
//                    DateValue = dateValue,
//                    Year = year,
//                    Month = 1,
//                    Day = 1,
//                    Decade = (year / 10) * 10
//                };
//                _context.Dates.Add(date);
//                await _context.SaveChangesAsync(); // Save to get the ID
//            }

//            return date;
//        }

//        private async Task<Studio> GetOrCreateDefaultStudioAsync()
//        {
//            var studio = await _context.Studios
//                .FirstOrDefaultAsync(s => s.StudioName == "Unknown Studio");

//            if (studio == null)
//            {
//                studio = new Studio { StudioName = "Unknown Studio" };
//                _context.Studios.Add(studio);
//                await _context.SaveChangesAsync(); // Save to get the ID
//            }

//            return studio;
//        }
//    }
//}
