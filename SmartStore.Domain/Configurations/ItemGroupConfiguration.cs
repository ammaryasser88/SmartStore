using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Configurations
{
    public class ItemGroupConfiguration : IEntityTypeConfiguration<ItemGroup>
    {
        public void Configure(EntityTypeBuilder<ItemGroup> builder)
        {
            builder.ToTable("ItemGroups");
            builder.HasKey(g => g.ItemGroupId);
            builder.Property(g => g.NameArabic).IsRequired().HasMaxLength(100);
            builder.Property(g => g.NameEnglish).IsRequired().HasMaxLength(100);
        }
    }

}
