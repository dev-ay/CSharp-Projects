﻿using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Core;

namespace GigHub.Controllers.Api
{



    //[Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend (AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId(); //"08974d88-9ec4-4553-a71a-1c6e45480e7e"; 

            //if (_unitOfWork.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            //    return BadRequest("The attendance already exists.");

            if(_unitOfWork.Attendances.GetFutureAttendance(dto.GigId, userId) != null)
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }


        //Input parameter must be called "id" as prescribed in WebApiConfig.cs
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine("Successfully called Delete method on {0}", id);

            var userId = User.Identity.GetUserId();

            //var attendance = _context.Attendances
            //    .Where(a => a.GigId == id && a.AttendeeId == userId)
            //    .FirstOrDefault();

            var attendance = _unitOfWork.Attendances.GetFutureAttendance(id, userId);

            if (attendance == null)
                return NotFound();
            else
            {
                _unitOfWork.Attendances.Remove(attendance);
                _unitOfWork.Complete();
                return Ok(id);
            }

        }

    }
}
