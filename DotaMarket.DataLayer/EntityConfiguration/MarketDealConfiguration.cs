using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class MarketDealConfiguration : BaseEntitiyConfiguration<MarketDeal>
    {
        public override void Configure(EntityTypeBuilder<MarketDeal> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Price)
                .IsRequired()
                .HasPrecision(18, 3);

            builder.HasOne(p => p.Item)
                .WithMany()
                .HasForeignKey(p => p.ItemId)
                .IsRequired();          
        }
    }
}