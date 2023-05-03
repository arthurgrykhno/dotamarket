using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Entities
{
    public class SteamTradeOffer : BaseEntity
    {
        public Guid TradePartnerId { get; set; }
        public User TradePartnerName { get; set; } = default!;
        public Guid MyAccountId { get; set; }
        public User MyAccountName { get; set; } = default!;
        public IEnumerable<Item>? MyItems { get; set; }
        public IEnumerable<Item>? TradePartnerItems { get; set; }
        public TradeOfferStatus Status { get; set; }
    }
}
