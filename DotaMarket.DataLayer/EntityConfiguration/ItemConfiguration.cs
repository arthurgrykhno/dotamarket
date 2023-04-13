using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class ItemConfiguration : BaseEntitiyConfiguration<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.ItemSlot).IsRequired();
            builder.Property(e => e.Hero).IsRequired();
            builder.Property(e => e.Rare).IsRequired();
            builder.Property(e => e.ItemPrice).IsRequired().HasPrecision(10,2);

            builder.HasOne(e => e.ItemHistory)
                .WithMany()
                .HasForeignKey(e => e.Id).IsRequired(false);

            builder.HasOne(a => a.Inventory)
                .WithMany()
                .HasForeignKey(e => e.InventoryId).IsRequired();
        }
    }
}