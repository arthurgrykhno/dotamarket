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

            builder.HasOne(e => e.ItemHistory)
                .WithMany()
                .HasForeignKey(e => e.ItemHistoryId)
                .IsRequired(false);

            builder.HasOne(e => e.Inventory)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.InventoryId)
                .IsRequired();
        }
    }
}