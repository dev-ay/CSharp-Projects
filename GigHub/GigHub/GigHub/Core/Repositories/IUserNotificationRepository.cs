using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<Notification> GetUnreadNotifications(string userId);
        IEnumerable<UserNotification> GetUnreadUserNotifications(string userId);

    }
}