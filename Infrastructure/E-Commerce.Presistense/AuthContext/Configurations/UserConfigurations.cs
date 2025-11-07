using E_Commerce.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Presistense.AuthContext.Configurations;
public class UserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName)
               .HasMaxLength(256)
               .IsRequired(false);

        builder.Property(u => u.LastName)
                .HasMaxLength(256)
                .IsRequired(false);

        builder.Property(u => u.DisplayName)
                .HasMaxLength(256)
                .IsRequired(false);

        builder.HasOne(u => u.Address)
               .WithOne(a => a.user)
               .HasForeignKey<Address>(a => a.UserId);
    }
}
