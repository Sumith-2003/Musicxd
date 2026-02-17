using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicxd.API.Services.Interfaces;

namespace Musicxd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IDataImportService _importService;

        public ImportController(IDataImportService importService)
        {
            _importService = importService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import()
        {
            return await _importService.MapDatatoEntity();
        }
    }
}
