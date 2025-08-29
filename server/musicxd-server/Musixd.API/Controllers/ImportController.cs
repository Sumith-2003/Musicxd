//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Musicxd.API.Services.Interfaces;

//namespace Musicxd.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImportController : ControllerBase
//    {
//        private readonly IAlbumImportService _importService;

//        public ImportController(IAlbumImportService importService)
//        {
//            _importService = importService;
//        }

//        [HttpPost("upload-excel")]
//        public async Task<IActionResult> UploadExcel(IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                return BadRequest("No file uploaded");
//            }

//            if (!IsValidExcelFile(file))
//            {
//                return BadRequest("Please upload a valid Excel file (.xlsx or .xls)");
//            }

//            try
//            {
//                using var stream = file.OpenReadStream();
//                var result = await _importService.ImportAlbumsFromExcelStreamAsync(stream);

//                if (result.Success)
//                {
//                    return Ok(new
//                    {
//                        message = result.Message,
//                        importedCount = result.ImportedCount,
//                        skippedCount = result.SkippedCount,
//                        errors = result.Errors
//                    });
//                }
//                else
//                {
//                    return BadRequest(new
//                    {
//                        message = result.Message,
//                        errors = result.Errors
//                    });
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPost("import-from-path")]
//        public async Task<IActionResult> ImportFromPath([FromBody] ImportPathRequest request)
//        {
//            if (string.IsNullOrWhiteSpace(request.FilePath))
//            {
//                return BadRequest("File path is required");
//            }

//            if (!System.IO.File.Exists(request.FilePath))
//            {
//                return BadRequest("File not found");
//            }

//            try
//            {
//                var result = await _importService.ImportAlbumsFromExcelAsync(request.FilePath);

//                if (result.Success)
//                {
//                    return Ok(new
//                    {
//                        message = result.Message,
//                        importedCount = result.ImportedCount,
//                        skippedCount = result.SkippedCount,
//                        errors = result.Errors
//                    });
//                }
//                else
//                {
//                    return BadRequest(new
//                    {
//                        message = result.Message,
//                        errors = result.Errors
//                    });
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        private static bool IsValidExcelFile(IFormFile file)
//        {
//            var allowedExtensions = new[] { ".xlsx", ".xls" };
//            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
//            return allowedExtensions.Contains(fileExtension);
//        }
//    }

//    public class ImportPathRequest
//    {
//        public string FilePath { get; set; } = string.Empty;
//    }
//}
