using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repository
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        List<Gig> GetUpcomingGigsByArtist(string artistId);
    }
}