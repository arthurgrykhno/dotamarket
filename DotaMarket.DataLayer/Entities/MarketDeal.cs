using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketDeal : BaseEntity
    {
        public Guid? ItemId { get; set; }
        public Item? Item { get; set; }
        public decimal Price { get; set; }
        public string Desrpition { get; set; }
        public ItemAction? ItemAction { get; set; }
    }
}