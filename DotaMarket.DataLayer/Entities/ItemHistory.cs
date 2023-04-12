using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class ItemHistory
    {
        public Guid Id { get; set; }
        public ItemAction? ItemAction { get; set; }
        
        public Guid? BuyerId { get; set; }
        public Guid? SellerId { get; set; }
    }
}
