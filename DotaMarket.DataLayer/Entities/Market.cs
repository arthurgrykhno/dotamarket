using System.ComponentModel.DataAnnotations;

namespace DotaMarket.DataLayer.Entities
{
    public class Market
    {
        
        public Guid Id { get; set; }

        public Guid? ItemId { get; set; }
        public Item? Items { get; set; }
    }
}
