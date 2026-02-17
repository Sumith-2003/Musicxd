using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Musicxd.API.DTO;
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
            try
            {
                var profiles = await _service.GetAllProfiles();
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving profiles.", details = ex.Message });
            }
        }

        [HttpGet("Profile/{name}")]
        public async Task<IActionResult> GetProfileByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { message = "Profile name cannot be null or empty." });

            if (name.Length > 50)
                return BadRequest(new { message = "Profile name cannot exceed 50 characters." });

            try
            {
                var profile = await _service.GetProfileByName(name);
                if (profile == null)
                    return NotFound(new { message = $"Profile with username '{name}' not found." });
                
                return Ok(profile);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the profile.", details = ex.Message });
            }
        }

        [HttpPost("CreateProfile")]
        public async Task<IActionResult> CreateProfile([FromBody] CreateProfileRequestDto dto)
        {
            try
            {
                var profile = await _service.CreateProfile(dto);
                return Ok(profile);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the profile.", details = ex.Message });
            }
        }

        [HttpPut("UpdateProfile/{name}")]
        public async Task<IActionResult> UpdateProfile(string name, [FromBody] UpdateProfileRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { message = "Profile name cannot be null or empty." });

            if (!string.IsNullOrEmpty(dto.UserName) && !string.Equals(name, dto.UserName, StringComparison.OrdinalIgnoreCase))
                return BadRequest(new { message = "Username in URL must match username in request body." });

            try
            {
                var profile = await _service.UpdateProfile(dto);
                return Ok(profile);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the profile.", details = ex.Message });
            }
        }

        [HttpDelete("DeleteProfile/{name}")]
        public async Task<IActionResult> DeleteProfile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { message = "Profile name cannot be null or empty." });

            if (name.Length > 50)
                return BadRequest(new { message = "Profile name cannot exceed 50 characters." });

            try
            {
                await _service.DeleteProfile(name);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the profile.", details = ex.Message });
            }
        }
    }
}
