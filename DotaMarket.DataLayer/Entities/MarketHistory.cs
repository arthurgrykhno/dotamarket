using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketHistory
    {
        public Guid Id { get; set; }
        
        public Guid? UserId { get; set; }
        
        public Guid? ItemId { get; set; }
    }
}
