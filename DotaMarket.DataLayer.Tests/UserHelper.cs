using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DotaMarket.DataLayer.Tests
{
    public class UserHelper
    {
        public List<User> GetUsers()
        {
            var users = new List<User>
            {
               new User
               {
                   Id = Guid.NewGuid(),
                   Name = "Alice",
                   Email = "alice@example.com",
                   Login = "alice",
                   Password = "123456",
                   MarketHistoryId = Guid.NewGuid()
               },
               new User
               {
                   Id = Guid.NewGuid(),
                   Name = "Bob",
                   Email = "bob@example.com",
                   Login = "bob",
                   Password = "123456",
                   MarketHistoryId = Guid.NewGuid()
               },
               new User
               {
                   Id = Guid.NewGuid(),
                   Name = "Charlie",
                   Email = "charlie@example.com",
                   Login = "charlie",
                   Password = "123456",
                   MarketHistoryId = Guid.NewGuid()
               }
            };

            return users;
        }
        public User GetUser()
        {
            var user = new User
            {
                Id = Guid.Parse("2cc76ef4-ab51-4acb-bd24-599513425207"),
                Name = "Alice",
                Email = "alice@example.com",
                Login = "alice",
                Password = "123456",
                MarketHistoryId = Guid.NewGuid()
            };
            return user;
        }
    }
}
