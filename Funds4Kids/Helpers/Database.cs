using Funds4Kids.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Funds4Kids.Helpers
{
    public class Database : DbContext
    {
        public Database()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<EventManager> Denominations { get; set; }
        public DbSet<EventManager> Donations { get; set; }
        public DbSet<EventManager> EventInfos { get; set; }
        public DbSet<EventManager> EventManagers { get; set; }
    }
}