using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class SteamTradeOffer : BaseEntity
    {
        public Guid OtherAccountId { get; set; }
        public User OtherAccountName { get; set; } = default!;
        public Guid MyAccountId { get; set; }
        public User MyAccountName { get; set; } = default!;
        public ICollection<Item>? MyItems { get; set; }
        public ICollection<Item>? OtherItems { get; set; }
        public TradeOfferStatus Status { get; set; }
    }
}
