namespace DotaMarket.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int? Age { get; set; }

        public Guid MarketHistoryId { get; set; }
        public IEnumerable<MarketHistory>? MarketHistory { get; set; }

        public Guid? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}