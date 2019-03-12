using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repository;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAttendanceRepository Attendances { get; set; }
        public IGigRepository Gigs { get; set; }
        public IFollowingRepository Followings { get; set; }
        public IGenreRepository Genres { get; set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Attendances = new AttendanceRepository(_context);
            Gigs = new GigRepository(_context);
            Followings = new FollowingRepository(_context);
            Genres = new GenreRepository(_context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}