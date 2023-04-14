using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class InventoryConfiguration : BaseEntitiyConfiguration<Inventory>
    {
        public override void Configure(EntityTypeBuilder<Inventory> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Items)
                .WithOne(e => e.Inventory)
                .HasForeignKey(e => e.InventoryId);


            builder.HasOne(e => e.User)
                .WithOne(e => e.Inventory)
                .HasForeignKey<Inventory>(e => e.UserId)
                .IsRequired();
        }
    }
}