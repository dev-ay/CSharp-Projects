using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScheduleIt2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Add the DbSet for all of the Models to be included as tables in the database
        public DbSet<Event> Events { get; set; }
        public DbSet<TimeOffEvent> TimeOffEvents { get; set; }
        public DbSet<WorkTimeEvent> WorkTimeEvents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TempSchedule> TempSchedules { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ScheduledWorkPeriod> ScheduledWorkPeriods { get; set; }
        public DbSet<ScheduleTemplate> ScheduleTemplate { get; set; }

        public System.Data.Entity.DbSet<ScheduleIt2.Models.Message> Messages { get; set; }
    }
}