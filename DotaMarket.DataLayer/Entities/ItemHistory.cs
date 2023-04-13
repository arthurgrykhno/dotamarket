using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class ItemHistory : BaseEntity
    {
        public ItemAction? ItemAction { get; set; }

        public Guid? BuyerId { get; set; }
        public User? Buyer { get; set; }

        public Guid? SellerId { get; set; }
        public User? Seller { get; set; }
    }
}