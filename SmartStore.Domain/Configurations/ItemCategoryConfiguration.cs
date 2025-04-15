using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;

namespace SmartStore.Domain.Configurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.NameArabic).IsRequired().HasMaxLength(100);
            builder.Property(c => c.NameEnglish).IsRequired().HasMaxLength(100);
        }
    }
}
