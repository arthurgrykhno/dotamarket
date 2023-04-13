using DotaMarket.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketHistory : BaseEntity
    {
        public ItemAction ItemAction { get; set; }

        public Guid? ItemId { get; set; }
        public Item? Items { get; set; }
    }
}