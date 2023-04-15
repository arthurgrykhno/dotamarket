using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class MarketHistoryConfiguration : BaseEntitiyConfiguration<MarketHistory>
    {
        public override void Configure(EntityTypeBuilder<MarketHistory> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.MarketDeal).IsRequired();

            builder.HasOne(e => e.Items)
                .WithMany()
                .HasForeignKey(e => e.ItemId)
                .IsRequired(false);
        }
    }
}