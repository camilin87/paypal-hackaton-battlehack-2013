using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FundsForKids.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.EventId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.ImageUrl)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Events");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CloseDate).HasColumnName("CloseDate");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
            this.Property(t => t.Goal).HasColumnName("Goal");
            this.Property(t => t.CoordinatorId).HasColumnName("CoordinatorId");
        }
    }
}
