using DotaMarket.DataLayer.Entities;
using Bogus;
using DotaMarket.DataLayer.Enums;

namespace DotaMarket.SteamApiGeneratore
{
    public class FakeItemGenerator
    {
        private readonly Faker<Item> _faker;

        public FakeItemGenerator()
        {
            _faker = new Faker<Item>()
                .RuleFor(i => i.Id, f => f.Random.Guid())
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.Hero, f => f.PickRandom<Hero>())
                .RuleFor(i => i.Rare, f => f.PickRandom<ItemRare>())
                .RuleFor(i => i.ItemSlot, f => f.PickRandom<ItemSlot>());
        }

        public Item GenerateItem()
        {
            return _faker.Generate();
        }

        public IEnumerable<Item> GenerateItems(int count)
        {
            return _faker.Generate(count);
        }
    }
}
