using Microsoft.EntityFrameworkCore;
using Musicxd.Domain.Entities;
using Musicxd.Infrastructure.Data;
using Musicxd.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Infrastructure.Repositories.Implementations
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;
        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Profile>> GetAllProfilesAsync() =>
            await _context.Profiles.ToListAsync();

        public async Task<Profile> GetProfileByNameAsync(string name) =>
            await _context.Profiles.FirstOrDefaultAsync(p => p.Username == name);

        public async Task<Profile> CreateProfileAsync(Profile profile)
        {
            _context.Profiles.Add(profile);
            //_context.Dates.Add(profile.DateJoined);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile> UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            //_context.Dates.Add(profile.DateJoined);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task DeleteProfileAsync(string name)
        {
            var profile = await _context.Profiles
                .Include(p => p.Reviews)
                .Include(p => p.Lists)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Username == name);

            if (profile == null)
                throw new ArgumentException("Profile not found");

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}