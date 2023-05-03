using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class SteamTradeOfferConfiguration : BaseEntitiyConfiguration<SteamTradeOffer>
    {
        public override void Configure(EntityTypeBuilder<SteamTradeOffer> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.TradePartnerName)
                .WithMany()
                .HasForeignKey(e => e.TradePartnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.MyAccountName)
                .WithMany()
                .HasForeignKey(e => e.MyAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.MyItems)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.TradePartnerItems)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}