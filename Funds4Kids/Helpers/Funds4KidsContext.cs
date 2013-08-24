using Funds4Kids.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Funds4Kids.Helpers
{
    public class Funds4KidsContext : DbContext
    {
        public Funds4KidsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<EventCoordinator> Denominations { get; set; }
        public DbSet<EventCoordinator> Donations { get; set; }
        public DbSet<EventCoordinator> EventInfos { get; set; }
        public DbSet<EventCoordinator> EventCoordinators { get; set; }
    }
}