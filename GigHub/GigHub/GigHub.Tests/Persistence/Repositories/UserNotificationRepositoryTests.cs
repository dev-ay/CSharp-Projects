using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repository;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class UserNotificationRepositoryTests
    {
        private UserNotificationRepository _repository;
        private Mock<DbSet<UserNotification>> _mockUserNotifications;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUserNotifications = new Mock<DbSet<UserNotification>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockUserNotifications.Object);

            _repository = new UserNotificationRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUnreadUserNotifications_UserNotificationsIsRead_ShouldNotBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);
            userNotification.Read();


            _mockUserNotifications.SetSource(new[] { userNotification });

            var userNotifications = _repository.GetUnreadUserNotifications("1");

            userNotifications.Should().BeEmpty();
        }


        [TestMethod]
        public void GetUnreadUserNotifications_UserHasNoUserNotifications_ShouldNotBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);


            _mockUserNotifications.SetSource(new[] { userNotification });

            var userNotifications = _repository.GetUnreadUserNotifications("9");

            userNotifications.Should().BeEmpty();
        }


        [TestMethod]
        public void GetUnreadUserNotifications_UserHasUserNotifications_ShouldBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);

            var notification2 = Notification.GigCanceled(gig);
            var userNotification2 = new UserNotification(user, notification2);

            _mockUserNotifications.SetSource(new[] { userNotification, userNotification2 });

            var userNotifications = _repository.GetUnreadUserNotifications("1");
                
            userNotifications.Should().HaveCount(2);
            userNotifications.First().Should().Be(userNotification);
        }

        [TestMethod]
        public void GetUnreadNotifications_UserNotificationsIsRead_ShouldBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);
            userNotification.Read();

            _mockUserNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetUnreadNotifications("1");

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUnreadNotifications_UserHasNoUserNotifications_ShouldBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);

            _mockUserNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetUnreadNotifications("9");

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUnreadNotifications_UserHasUserNotifications_ShouldBeReturned()
        {
            var user = new ApplicationUser() { Id = "1" };
            var gig = new Gig();
            var notification = Notification.GigCreated(gig);
            var userNotification = new UserNotification(user, notification);

            var notification2 = Notification.GigCanceled(gig);
            var userNotification2 = new UserNotification(user, notification2);

            _mockUserNotifications.SetSource(new[] { userNotification, userNotification2 });

            var notifications = _repository.GetUnreadNotifications("1");

            notifications.Should().HaveCount(2);
            notifications.First().Should().Be(notification);
        }

    }
}
