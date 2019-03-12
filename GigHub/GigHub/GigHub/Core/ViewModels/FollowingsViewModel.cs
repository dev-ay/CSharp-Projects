using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class FollowingsViewModel
    {
        public IEnumerable<ApplicationUser> Artists { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}