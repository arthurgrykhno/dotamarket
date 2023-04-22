using DotaMarket.DataLayer.Entities;

namespace DotaMarket.DataLayer.Specification
{
    public class ItemWithHighPriceSpecification : BaseSpecification<MarketDeal>
    {
        public ItemWithHighPriceSpecification()
        {
            AddCriteria(deal => deal.Price >= 200.00m);
        }
    }
}