using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FundsForKids.Models.Mapping
{
    public class DenominationMap : EntityTypeConfiguration<Denomination>
    {
        public DenominationMap()
        {
            // Primary Key
            this.HasKey(t => t.DenominationId);

            // Properties
            this.Property(t => t.Amount)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Denominations");
            this.Property(t => t.DenominationId).HasColumnName("DenominationId");
            this.Property(t => t.Amount).HasColumnName("Amount");
        }
    }
}
