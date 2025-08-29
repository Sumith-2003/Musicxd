using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicxd.API.Services.Implementations;

namespace Musicxd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _service;
        public ProfileController(ProfileService service)
        {
            _service = service;
        }
        [HttpGet("AllProfiles")]
        public async Task<IActionResult> GetAllProfiles()
        {
            var profiles = await _service.GetAllProfiles();
            return Ok(profiles);
        }
    }
}
