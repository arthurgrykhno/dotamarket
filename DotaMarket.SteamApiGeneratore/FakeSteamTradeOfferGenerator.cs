using Bogus;
using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Enums;

namespace DotaMarket.SteamApiGeneratore
{
    public class FakeSteamTradeOfferGenerator
    {
        private readonly Faker<SteamTradeOffer> _faker;

        public FakeSteamTradeOfferGenerator()
        {
            _faker = new Faker<SteamTradeOffer>()
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.TradePartnerId, f => f.Random.Guid())
            .RuleFor(o => o.TradePartnerName.Name, f => f.Person.UserName)
            .RuleFor(o => o.MyAccountId, f => f.Random.Guid())
            .RuleFor(o => o.MyAccountName.Name, f => f.Person.UserName)
            .RuleFor(o => o.MyItems, f => new List<Item>())
            .RuleFor(o => o.TradePartnerItems, f => new List<Item>())
            .RuleFor(o => o.Status, f => f.PickRandom<TradeOfferStatus>());
        }

        public SteamTradeOffer Generate()
        {
            return _faker.Generate();
        }
    }
}