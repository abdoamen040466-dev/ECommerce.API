using E_Commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Presistense.Context.Configurations;
internal class OrderConfiguration
    : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.DeliveryMethod)
            .WithMany()
            .HasForeignKey(o => o.DeliveryMethodId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.OwnsOne(o => o.Address, x => x.WithOwner());

        builder.HasIndex(o => o.UserEmail);

        builder.Property(o => o.SubTotal)
            .HasColumnType("decimal(10, 2)");

        builder.Property(o => o.UserEmail)
            .HasColumnType("VarChar")
            .HasMaxLength(128);

        builder.Property(o => o.Status)
            .HasConversion<string>();

        builder.Property(o => o.PaymentIntentId)
            .HasColumnType("VarChar")
            .HasMaxLength(128);
    }

}
