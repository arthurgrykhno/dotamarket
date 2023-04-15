using DotaMarket.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketHistory : BaseEntity
    {
       public MarketDeal MarketDeal { get; set; }

        public Guid? ItemId { get; set; }
        public Item? Item { get; set; }
    }
}