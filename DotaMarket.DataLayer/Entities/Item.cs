using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string NameItem { get; set; }
        public Hero Hero { get; set; }
        public ItemRare Rare { get; set; }
        public ItemSlot ItemSlot { get; set; }
        public decimal ItemPrice { get; set; }

        public ItemHistory? ItemHistory { get; set; }

        public Guid InventoryId { get; set; }
    }
}
