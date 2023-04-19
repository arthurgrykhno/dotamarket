using DotaMarket.DataLayer.Entities;

namespace DotaMarket.DataLayer.Specification
{
    public class ItemWithHighPriceSpecification : BaseSpecification<MarketDeal>
    {
        public ItemWithHighPriceSpecification()
            : base(u => u.Price >= 200.00m)
        {

        }
    }
}