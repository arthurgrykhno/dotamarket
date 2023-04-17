using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class MarketHistoryConfiguration : BaseEntitiyConfiguration<MarketHistory>
    {
        public override void Configure(EntityTypeBuilder<MarketHistory> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.MarketHistory)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasOne(e => e.MarketDeal)
                .WithOne()
                .HasForeignKey<MarketHistory>(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.MarketDeal)
                .WithMany()
                .HasForeignKey(e => e.MarketDealId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}