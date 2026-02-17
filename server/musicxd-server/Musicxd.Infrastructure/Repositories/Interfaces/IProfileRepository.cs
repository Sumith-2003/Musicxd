using Musicxd.Domain.Entities;

namespace Musicxd.Infrastructure.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileByNameAsync(string name);
        Task<Profile> CreateProfileAsync(Profile profile);
        Task<Profile> UpdateProfileAsync(Profile profile);
        Task DeleteProfileAsync(string name);
    }
}
