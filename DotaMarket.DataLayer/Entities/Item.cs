using DotaMarket.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public Hero Hero { get; set; }
        public ItemRare Rare { get; set; }
        public ItemSlot ItemSlot { get; set; }
        public decimal? ItemPrice { get; set; }

        public ItemHistory? ItemHistory { get; set; }

        [ForeignKey("Inventory")]
        public Guid InventoryId { get; set; }
    }
}
