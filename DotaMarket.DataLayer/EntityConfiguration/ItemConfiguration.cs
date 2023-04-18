using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class ItemConfiguration : BaseEntitiyConfiguration<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ItemSlot)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Hero)
                .IsRequired();

            builder.Property(e => e.Rare)
                .IsRequired();

            builder.HasMany(i => i.OrderHistoryRow)
            .WithOne(o => o.Item)
            .HasForeignKey(o => o.ItemId);

            builder.HasOne(e => e.Inventory)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.InventoryId)
                .IsRequired();
        }
    }
}