using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer
{
    public class DotaMarketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MarketDeal> MarketDeals { get; set; }
        public DbSet<MarketHistory> MarketHistories { get; set; }
        public DbSet<OrderHistoryRow> OrderHistoryRows { get; set; }
       
        public DotaMarketContext(DbContextOptions<DotaMarketContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderHistoryRowConfiguration());
            modelBuilder.ApplyConfiguration(new MarketDealConfiguration());
            modelBuilder.ApplyConfiguration(new MarketHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}