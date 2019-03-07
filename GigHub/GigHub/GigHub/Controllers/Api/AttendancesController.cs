using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{



    //[Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend (AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId(); //"08974d88-9ec4-4553-a71a-1c6e45480e7e"; 

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exists.");


            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }


        //Input parameter must be called "id" as prescribed in WebApiConfig.cs
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine("Successfully called Delete method on {0}", id);

            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances
                .Where(a => a.GigId == id && a.AttendeeId == userId)
                .FirstOrDefault();

            if (attendance == null)
                return NotFound();
            else
            {
                _context.Attendances.Remove(attendance);
                _context.SaveChanges();
                return Ok(id);
            }

        }

    }
}
