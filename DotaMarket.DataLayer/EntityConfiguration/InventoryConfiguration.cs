using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class InventoryConfiguration : BaseEntitiyConfiguration<Inventory>
    {
        public override void Configure(EntityTypeBuilder<Inventory> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ItemId).IsRequired(false);
            builder.Property(e => e.UserId).IsRequired(false);

            builder.HasOne(e => e.Items)
                .WithMany()
                .HasForeignKey(e => e.ItemId)
                .IsRequired(false);


            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);
        }
    }
}