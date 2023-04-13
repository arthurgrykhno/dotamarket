namespace DotaMarket.DataLayer.Entities
{
    public class MarketDeals : BaseEntity
    {
        
        public Guid? ItemsId { get; set; }
        public Item? Items { get; set; }
    }
}