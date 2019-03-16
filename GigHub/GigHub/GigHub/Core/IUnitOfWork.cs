using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; set; }
        IFollowingRepository Followings { get; set; }
        IGenreRepository Genres { get; set; }
        IGigRepository Gigs { get; set; }
        IUserNotificationRepository UserNotifications { get; set; }

        void Complete();
    }
}