using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _context = new ApplicationDbContext();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.UserNotifications.GetUnreadNotifications(userId);
            //var notifications = _context.UserNotifications
            //    .Where(un => un.UserId == userId && !un.IsRead)
            //    .Select(un => un.Notification)
            //    .Include(n => n.Gig.Artist)
            //    .ToList();

            //Utilizing AutoMapper
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }


        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var userNotifications = _unitOfWork.UserNotifications.GetUnreadUserNotifications(userId);
            //var notifications = _context.UserNotifications
            //    .Where(un => un.UserId == userId && !un.IsRead)
            //    .ToList();

            //userNotifications.ForEach(n => n.Read());
            foreach (var un in userNotifications)
            {
                un.Read();
            }

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
