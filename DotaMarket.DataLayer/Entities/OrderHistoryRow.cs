using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class OrderHistoryRow : BaseEntity
    {
        public ItemAction ItemAction { get; set; }
        
        public Guid ItemId { get; set; }
        public Item Item { get; set; } = default!;

        public Guid BuyerId { get; set; }
        public User Buyer { get; set; } = default!;

        public Guid SellerId { get; set; }
        public User Seller { get; set; } = default!;
    }
}