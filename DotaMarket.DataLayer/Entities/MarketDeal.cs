using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketDeal : BaseEntity
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; } = default!;

        public decimal Price { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ItemAction ItemAction { get; set; } = default!;
    }
}