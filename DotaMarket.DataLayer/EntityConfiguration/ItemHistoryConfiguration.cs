using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class ItemHistoryConfiguration : BaseEntitiyConfiguration<ItemHistory>
    {
        public override void Configure(EntityTypeBuilder<ItemHistory> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ItemAction).IsRequired(false);

            builder.HasOne(p => p.Buyer)
                .WithMany()
                .HasForeignKey(p => p.BuyerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);


            builder.HasOne(p => p.Seller)
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}