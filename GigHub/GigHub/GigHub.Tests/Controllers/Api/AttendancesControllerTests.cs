using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using Moq;
using GigHub.Core.Repositories;
using GigHub.Core;
using GigHub.Tests.Extensions;
using FluentAssertions;
using System.Web.Http.Results;
using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class AttendancesControllerTests
    {
        private AttendancesController _controller;
        private Mock<IAttendanceRepository> _mockRepository;
        private string _userId;
        private int _gigId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IAttendanceRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Attendances).Returns(_mockRepository.Object);

            _controller = new AttendancesController(mockUoW.Object);
            _userId = "1";
            _gigId = 10;
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod]
        public void Attend_AttendanceAlreadyExists_ShouldReturnBadRequest()
        {
            var attendanceDto = new AttendanceDto { GigId = _gigId };
            var attendance = new Attendance() { GigId = _gigId, AttendeeId = _userId };
            _mockRepository.Setup(a => a.GetFutureAttendance(_gigId, _userId)).Returns(attendance);
            var result = _controller.Attend(attendanceDto);
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void Attend_ValidRequest_ShouldReturnOk()
        {
            var attendanceDto = new AttendanceDto { GigId = _gigId };
            //var attendance = new Attendance() { GigId = _gigId, AttendeeId = _userId };
            //_mockRepository.Setup(a => a.GetFutureAttendance(_gigId, _userId)).Returns(attendance);
            var result = _controller.Attend(attendanceDto);
            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void Delete_NoAttendanceExists_ShouldReturnNotFound()
        {
            var result = _controller.Delete(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Delete_ValidRequest_ShouldReturnOk()
        {
            var attendance = new Attendance { GigId = _gigId, AttendeeId = _userId };

            _mockRepository.Setup(a => a.GetFutureAttendance(_gigId,_userId)).Returns(attendance);

            var result = _controller.Delete(_gigId);

            result.Should().BeOfType<OkNegotiatedContentResult<int>>();
        }
    }
}
