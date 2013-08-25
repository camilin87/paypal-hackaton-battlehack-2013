using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FundsForKids.Models.Mapping;

namespace FundsForKids.Models
{
    public partial class Fund4KidsContext : DbContext
    {
        static Fund4KidsContext()
        {
            Database.SetInitializer<Fund4KidsContext>(null);
        }

        public Fund4KidsContext()
            : base("Name=Fund4KidsContext")
        {
        }

        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<EventDenomination> EventDenominations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CoordinatorMap());
            modelBuilder.Configurations.Add(new DenominationMap());
            modelBuilder.Configurations.Add(new DonationMap());
            modelBuilder.Configurations.Add(new EventDenominationMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
        }
    }
}
