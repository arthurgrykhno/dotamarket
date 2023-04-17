using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class UserConfiguration : BaseEntitiyConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Age)
                .IsRequired(false)
                .HasMaxLength(3);

            builder.HasMany(e => e.MarketHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Inventory)
                .WithOne(e => e.User)
                .HasForeignKey<Inventory>(e => e.Id)
                .IsRequired(false);
        }
    }
}