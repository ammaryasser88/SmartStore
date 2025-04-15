using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;

namespace SmartStore.Domain.Configurations
{
    public class DamagedItemConfiguration : IEntityTypeConfiguration<DamagedItem>
    {
        public void Configure(EntityTypeBuilder<DamagedItem> builder)
        {
            builder.ToTable("DamagedItems");
            builder.HasKey(d => d.DamagedItemId);
            builder.Property(d => d.Quantity).HasColumnType("decimal(18,2)");
            builder.Property(d => d.Reason).IsRequired().HasMaxLength(250);
            builder.Property(d => d.Date).HasColumnType("datetime");

            builder.HasOne(d => d.Item)
                   .WithMany(i => i.DamagedItems)
                   .HasForeignKey(d => d.ItemId);

            builder.HasOne(d => d.Store)
                   .WithMany(s => s.DamagedItems)
                   .HasForeignKey(d => d.StoreId);
        }
    }
}
