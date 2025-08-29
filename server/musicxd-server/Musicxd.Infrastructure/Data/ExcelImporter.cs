//using OfficeOpenXml;
//using Musicxd.Domain.Entities;

//namespace Musicxd.Infrastructure.Data
//{
//    public class ExcelImporter
//    {
//        private readonly DataContext _dbContext;
//        public ExcelImporter(DataContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<List<Artist>> ImportArtistsFromExcelAsync(string filePath)
//        {
//            var artists = new List<Artist>();

//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            using var package = new ExcelPackage(new FileInfo(filePath));
//            var worksheet = package.Workbook.Worksheets[0];

//            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
//            {
//                var albumTitle = worksheet.Cells[row, 1].Value?.ToString();
//                var artistName = worksheet.Cells[row, 2].Value?.ToString();

//                if (!string.IsNullOrWhiteSpace(artistName))
//                {
//                    var existingArtist = artists.FirstOrDefault(a => a.Name.Equals(artistName, StringComparison.OrdinalIgnoreCase));

//                    if (existingArtist == null)
//                    {
//                        existingArtist = new Artist
//                        {
//                            Name = artistName,
//                            Albums = new List<Album>()
//                        };
//                        artists.Add(existingArtist);
//                        await _dbContext.AddAsync(existingArtist);
//                        await _dbContext.SaveChangesAsync(); 
//                    }

//                    if (!string.IsNullOrWhiteSpace(albumTitle) && !existingArtist.Albums.Any(a => a.AlbumName.Equals(albumTitle, StringComparison.OrdinalIgnoreCase)))
//                    {
//                        existingArtist.Albums.Add(new Album
//                        {
//                            AlbumName = albumTitle
//                        });
//                    }
//                }
//            }
//            return artists;
//        }
//    }
//}
