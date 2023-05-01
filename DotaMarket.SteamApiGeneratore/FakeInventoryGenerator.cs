using Bogus;
using DotaMarket.DataLayer.Entities;

namespace DotaMarket.SteamApiGeneratore
{
    public class FakeInventoryGenerator
    {
        private readonly Faker<Inventory> _faker;

        public FakeInventoryGenerator()
        {
            _faker = new Faker<Inventory>()
                .RuleFor(i => i.Id, f => f.Random.Guid())
                .RuleFor(i => i.UserId, f => f.Random.Guid());
        }

        public Inventory GenerateInventory(int itemCount)
        {
            var inventory = _faker.Generate();
            var items = new List<Item>();

            for (int i = 0; i < itemCount; i++)
            {
                items.Add(new FakeItemGenerator().GenerateItem());
            }

            inventory.Items = items;

            return inventory;
        }
    }
}
