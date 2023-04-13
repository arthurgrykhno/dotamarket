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
       
        public DotaMarketContext(DbContextOptions<DotaMarketContext> options)
            : base(options)
        {

        }
    }
}
