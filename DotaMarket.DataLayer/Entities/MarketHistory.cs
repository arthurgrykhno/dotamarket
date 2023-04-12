using System.ComponentModel.DataAnnotations.Schema;

namespace DotaMarket.DataLayer.Entities
{
    public class MarketHistory
    {
        public Guid Id { get; set; }
        
        public Guid BuyId { get; set; }
        
        public Guid SaleId { get; set; }
    }
}
