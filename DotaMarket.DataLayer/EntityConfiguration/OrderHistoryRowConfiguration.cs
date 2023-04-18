using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class OrderHistoryRowConfiguration : BaseEntitiyConfiguration<OrderHistoryRow>
    {
        public override void Configure(EntityTypeBuilder<OrderHistoryRow> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Item)
                .WithMany(i => i.OrderHistoryRows)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Buyer)
                .WithMany()
                .HasForeignKey(p => p.BuyerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(p => p.Seller)
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}