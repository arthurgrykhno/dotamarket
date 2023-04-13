using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }


        public Guid ActionHistoryId { get; set; }
        public MarketHistory? ActionHistory { get; set; }


        public Guid? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

    }
}