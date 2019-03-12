using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repository
{
    public class FollowingRepository : IFollowingRepository
    {

        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string ArtistId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == ArtistId && f.FollowerId == userId);
        }

        public IEnumerable<ApplicationUser> GetFollowees(string userId)
        {
            return _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee)
                //.Include(g => g.Name)
                .ToList();
        }
    }
}