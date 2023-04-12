using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class User
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }

        public MarketHistory? ActionHistory { get; set; }
        [ForeignKey("Inventory")]
        public Guid? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

    }
}
