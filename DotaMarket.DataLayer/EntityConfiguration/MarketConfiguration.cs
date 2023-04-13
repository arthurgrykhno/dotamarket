using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class MarketDealsConfiguration : BaseEntitiyConfiguration<MarketDeals>
    {
        public override void Configure(EntityTypeBuilder<MarketDeals> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Items)
                .WithMany()
                .HasForeignKey(p => p.ItemsId)
                .IsRequired(false);
        }
    }
}