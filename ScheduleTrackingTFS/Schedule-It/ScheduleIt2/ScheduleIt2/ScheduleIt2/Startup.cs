using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ScheduleIt2.Models;

[assembly: OwinStartupAttribute(typeof(ScheduleIt2.Startup))]
namespace ScheduleIt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
