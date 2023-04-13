using DotaMarket.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class ItemHistory : BaseEntity
    {
        public ItemAction? ItemAction { get; set; }

        [ForeignKey("User")]
        public Guid? BuyerId { get; set; }

        [ForeignKey("User")]
        public Guid? SellerId { get; set; }
    }
}
