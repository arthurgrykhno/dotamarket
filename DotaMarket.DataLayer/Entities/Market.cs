using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class Market : BaseEntity
    {
        

        [ForeignKey("Item")]
        public Guid? ItemId { get; set; }
        public Item? Items { get; set; }
    }
}
