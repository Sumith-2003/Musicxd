using Musicxd.API.DTO;
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
    }
}
