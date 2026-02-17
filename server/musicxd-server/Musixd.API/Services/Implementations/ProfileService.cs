using Musicxd.API.DTO;
using Musicxd.API.Mapper;
using Musicxd.Domain.Entities;
using Musicxd.Infrastructure.Data;
using Musicxd.Infrastructure.Repositories.Implementations;

namespace Musicxd.API.Services.Implementations
{
    public class ProfileService
    {
        private readonly ProfileRepository _profileRepository;
        public ProfileService(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _profileRepository.GetAllProfilesAsync();
        }

        public async Task<Profile> GetProfileByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Profile name cannot be null or empty.");

            return await _profileRepository.GetProfileByNameAsync(name);
        }

        public async Task<Profile> CreateProfile(CreateProfileRequestDto dto)
        {
            await ValidateUsernameUniqueness(dto.UserName);
            ValidateWebsiteFormat(dto.Website);
            var profile = new MappingProfiles().ToEntity(dto);
            return await _profileRepository.CreateProfileAsync(profile);
        }

        public async Task<Profile> UpdateProfile(UpdateProfileRequestDto dto)
        {
            var existingProfile = await _profileRepository.GetProfileByNameAsync(dto.UserName);
            if (existingProfile == null)
                throw new ArgumentException($"Profile with username '{dto.UserName}' not found.");

            ValidateWebsiteFormat(dto.Website);
            var profile = new MappingProfiles().ToEntity(dto);
            return await _profileRepository.UpdateProfileAsync(profile);
        }

        public async Task DeleteProfile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Profile name cannot be null or empty.");

            if (name.Length > 50)
                throw new ArgumentException("Profile name cannot exceed 50 characters.");

            var existingProfile = await _profileRepository.GetProfileByNameAsync(name);
            if (existingProfile == null)
                throw new ArgumentException($"Profile with username '{name}' not found.");

            await _profileRepository.DeleteProfileAsync(name);
        }

        private async Task ValidateUsernameUniqueness(string username)
        {
            var existingProfile = await _profileRepository.GetProfileByNameAsync(username);
            if (existingProfile != null)
                throw new InvalidOperationException($"Username '{username}' is already taken.");
        }

        private static void ValidateWebsiteFormat(string? website)
        {
            if (!string.IsNullOrEmpty(website))
            {
                if (!Uri.TryCreate(website, UriKind.Absolute, out var uri) || 
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    throw new ArgumentException("Website must be a valid HTTP or HTTPS URL.");
                }
            }
        }
    }
}
