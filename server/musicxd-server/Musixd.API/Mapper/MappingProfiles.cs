using Musicxd.API.DTO;
using Musicxd.Domain.Entities;

namespace Musicxd.API.Mapper
{
    public class MappingProfiles
    {
        public Profile ToEntity(CreateProfileRequestDto dto)
        {
            var profile = new Profile
            {
                Username = dto.UserName,
                Location = dto.Location,
                Website = dto.Website,
                Bio = dto.Bio
            };

            return profile;
        }

        public Profile ToEntity(UpdateProfileRequestDto dto)
        {
            var profile = new Profile
            {
                Username = dto.UserName,
                Location = dto.Location,
                Website = dto.Website,
                Bio = dto.Bio
            };

            return profile;
        }
    }
}
