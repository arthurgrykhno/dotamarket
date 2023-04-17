namespace DotaMarket.DataLayer.Entities
{
    public class MarketHistory : BaseEntity
    {
        public Guid? ItemId { get; set; }
        public Item? Item { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid? MarketDealId { get; set; }
        public MarketDeal MarketDeal { get; set; }
    }
}