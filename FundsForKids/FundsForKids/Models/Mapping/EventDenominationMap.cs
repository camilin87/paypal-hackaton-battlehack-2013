using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FundsForKids.Models.Mapping
{
    public class EventDenominationMap : EntityTypeConfiguration<EventDenomination>
    {
        public EventDenominationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventDenominations");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.DenominationId).HasColumnName("DenominationId");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
