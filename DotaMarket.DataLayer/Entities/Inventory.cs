namespace DotaMarket.DataLayer.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid? ItemId { get; set; }
        public Item? Items { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}