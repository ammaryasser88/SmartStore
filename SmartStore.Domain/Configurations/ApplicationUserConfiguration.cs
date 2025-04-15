using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Entities;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);
    }
}
