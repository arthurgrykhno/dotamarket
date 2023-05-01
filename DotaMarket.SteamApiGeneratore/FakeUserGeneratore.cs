using Bogus;
using DotaMarket.DataLayer.Entities;

namespace DotaMarket.SteamApiGeneratore
{
    public class FakeUserGenerator
    {
        private readonly Faker<User> _faker;

        public FakeUserGenerator()
        {
            _faker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.Login, f => f.Person.UserName)
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Age, f => f.Random.Int(10, 100))
                .RuleFor(u => u.MarketHistoryId, f => Guid.NewGuid())
                .RuleFor(u => u.InventoryId, f => Guid.NewGuid());
        }

        public IEnumerable<User> GenerateUsers(int count)
        {
            return _faker.Generate(count);
        }
    }
}