using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FundsForKids.Models.Mapping
{
    public class CoordinatorMap : EntityTypeConfiguration<Coordinator>
    {
        public CoordinatorMap()
        {
            // Primary Key
            this.HasKey(t => t.CoordinatorId);

            // Properties
            this.Property(t => t.PaypalEmail)
                .HasMaxLength(250);

            this.Property(t => t.UserId);

            // Table & Column Mappings
            this.ToTable("Coordinators");
            this.Property(t => t.CoordinatorId).HasColumnName("CoordinatorId");
            this.Property(t => t.PaypalEmail).HasColumnName("PaypalEmail");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
