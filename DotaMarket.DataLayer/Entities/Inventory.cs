namespace DotaMarket.DataLayer.Entities
{
    public class Inventory : BaseEntity
    {
        public IEnumerable<Item>? Items { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}