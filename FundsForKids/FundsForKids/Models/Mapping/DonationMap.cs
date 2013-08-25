using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FundsForKids.Models.Mapping
{
    public class DonationMap : EntityTypeConfiguration<Donation>
    {
        public DonationMap()
        {
            // Primary Key
            this.HasKey(t => t.DonationId);

            // Properties
            this.Property(t => t.SenderEmail)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Donations");
            this.Property(t => t.DonationId).HasColumnName("DonationId");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.SenderEmail).HasColumnName("SenderEmail");
            this.Property(t => t.Amoun).HasColumnName("Amoun");
            this.Property(t => t.EventId).HasColumnName("EventId");
        }
    }
}
