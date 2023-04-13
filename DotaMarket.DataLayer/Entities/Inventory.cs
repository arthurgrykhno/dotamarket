
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class Inventory : BaseEntity
    {

        [ForeignKey("Item")]
        public Guid? ItemId { get; set; }
        public Item? Items { get; set; }
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }

    }
}
