using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; } = default!;
        public Hero Hero { get; set; }
        public ItemRare Rare { get; set; }
        public ItemSlot ItemSlot { get; set; }

        public IEnumerable<OrderHistoryRow>? OrderHistoryRows { get; set; }

        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; } = default!;
    }
}