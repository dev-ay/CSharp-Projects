using GigHub.Repository;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; set; }
        IFollowingRepository Followings { get; set; }
        IGenreRepository Genres { get; set; }
        IGigRepository Gigs { get; set; }

        void Complete();
    }
}