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

            builder.Property(e => e.OtherAccountId)
                .IsRequired();

            builder.Property(e => e.MyAccountId)
                .IsRequired();

            builder.HasOne(e => e.OtherAccountName)
                .WithMany()
                .HasForeignKey(e => e.OtherAccountId)
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

            builder.HasMany(e => e.OtherItems)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}