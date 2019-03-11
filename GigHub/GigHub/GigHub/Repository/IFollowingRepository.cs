using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repository
{
    public interface IFollowingRepository
    {
        IEnumerable<ApplicationUser> GetFollowees(string userId);
        Following GetFollowing(string userId, string ArtistId);
    }
}