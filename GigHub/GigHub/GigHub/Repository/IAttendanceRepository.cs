using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repository
{
    public interface IAttendanceRepository
    {
        Attendance GetFutureAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}