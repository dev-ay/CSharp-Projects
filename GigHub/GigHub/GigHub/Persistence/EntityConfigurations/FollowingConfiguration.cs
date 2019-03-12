using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            //Key Configurations
            HasKey(f => new { f.FollowerId, f.FolloweeId });
        }
    }
}