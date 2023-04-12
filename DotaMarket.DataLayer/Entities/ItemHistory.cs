using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class ItemHistory
    {
        public Guid Id { get; set; }
        public ItemAction ItemAction { get; set; }
        
        public Guid FromId { get; set; }
        public User? From { get; set; }

        public Guid ToId { get; set; }
        public User? To { get; set; }
    }
}
