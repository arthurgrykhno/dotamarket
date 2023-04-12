using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer
{
    public class DotaMarketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<MarketHistory> MarketHistories { get; set; }
        public DbSet<ItemHistory> ItemHistories { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ItemHistory>()
        //        .HasOne(i => i.To)
        //        .WithMany()
        //        .HasForeignKey(i => i.ToId)
        //        .OnDelete(DeleteBehavior.NoAction)
        //        .IsRequired(false);

        //    modelBuilder.Entity<ItemHistory>()
        //        .HasOne(i => i.From)
        //        .WithMany()
        //        .HasForeignKey(i => i.FromId)
        //        .OnDelete(DeleteBehavior.NoAction)
        //        .IsRequired(false);




        //}
        public DotaMarketContext(DbContextOptions<DotaMarketContext> options)
            : base(options)
        {

        }
    }
}
