namespace DotaMarket.DataLayer.Entities
{
    public class User
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }

        public IEnumerable<MarketHistory>? ActionHistory { get; set; }

        public Guid InventoryId { get; set; }
        public IEnumerable<Inventory>? Inventory { get; set; }

    }
}
