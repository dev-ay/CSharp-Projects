using GigHub.Models;
using GigHub.Repository;

namespace GigHub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository Attendances { get; set; }
        public GigRepository Gigs { get; set; }
        public FollowingRepository Followings { get; set; }
        public GenreRepository Genres { get; set; }


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