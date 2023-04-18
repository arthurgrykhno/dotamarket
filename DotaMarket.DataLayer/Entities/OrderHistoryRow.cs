using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class OrderHistoryRow : BaseEntity
    {
        public ItemAction ItemAction { get; set; }
        
        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public Guid BuyerId { get; set; }
        public User Buyer { get; set; }

        public Guid SellerId { get; set; }
        public User Seller { get; set; }
    }
}