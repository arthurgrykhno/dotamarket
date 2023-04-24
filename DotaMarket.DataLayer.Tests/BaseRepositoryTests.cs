using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer.Tests
{
    public class BaseRepositoryTests
    {
        private DbContextOptions<DotaMarketContext> _options;

        public BaseRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DotaMarketContext>()
                 .UseInMemoryDatabase(databaseName: "TestDatabase")
                 .Options;

            using (var context = new DotaMarketContext(_options))
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    Email = "asdasdasdasd",
                    Login = "aaaaa",
                    Password = "213123asd",
                    MarketHistoryId = Guid.NewGuid()
                });

                context.SaveChanges();
            }
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Alice",
                Email = "alice@example.com",
                Login = "alice",
                Password = "123456",
                MarketHistoryId = Guid.NewGuid()
            };

            using var context = new DotaMarketContext(_options);
            var userRepository = new BaseRepository<User>(context);

            await userRepository.AddAsync<User>(user);
            var result = userRepository.FindById<User>(user.Id);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityInDatabase()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Alice",
                Email = "alice@example.com",
                Login = "alice",
                Password = "123456",
                MarketHistoryId = Guid.NewGuid()
            };
            using var context = new DotaMarketContext(_options);
            var userRepository = new BaseRepository<User>(context);
            await userRepository.AddAsync<User>(user);

            user.Name = "Test1";
            userRepository.UpdateAsync<User>(user);
            var result = userRepository.FindById<User>(user.Id);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveEntityFromDatabase()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Alice",
                Email = "alice@example.com",
                Login = "alice",
                Password = "123456",
                MarketHistoryId = Guid.NewGuid()
            };

            using var context = new DotaMarketContext(_options);
            var userRepository = new BaseRepository<User>(context);
            await userRepository.AddAsync<User>(user);

            await userRepository.DeleteAsync<User>(user);
            var result = userRepository.FindById<User>(user.Id);

            result.Should().BeNull();
        }

        [Fact]
        public async Task FindById_ShouldReturnEntityFromDatabase()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = "Alice",
                Email = "alice@example.com",
                Login = "alice",
                Password = "123456",
                MarketHistoryId = Guid.NewGuid()
            };

            using var context = new DotaMarketContext(_options);
            var userRepository = new BaseRepository<User>(context);
            await userRepository.AddAsync<User>(user);

            var result = userRepository.FindById<User>(user.Id);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldAddRangeEntitiesInDataBase()
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

            using (var context = new DotaMarketContext(_options))
            {
                var repository = new BaseRepository<User>(context);

                var addUsers = await repository.AddRangeAsync<User>(users);

                addUsers.Should().BeEquivalentTo(users);
                context.Users.Should().HaveCount(4);
            }
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldUpdateEntitiesInDatabase()
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

            using (var context = new DotaMarketContext(_options))
            {
                var repository = new BaseRepository<User>(context);
                var addUsers = await repository.AddRangeAsync<User>(users);

                foreach (var user in users)
                {
                    user.Name = "Updated Name";
                }

                repository.UpdateRangeAsync<User>(users);

                foreach (var user in users)
                {
                    var updatedUser = repository.FindById<User>(user.Id);
                    updatedUser.Should().NotBeNull();
                    updatedUser.Name.Should().Be("Updated Name");
                }
            }
        }

        [Fact]
        public async Task DeleteRangeAsync_ShouldRemoveEntitiesFromDatabase()
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

            using (var context = new DotaMarketContext(_options))
            {
                var userRepository = new BaseRepository<User>(context);
                await userRepository.AddRangeAsync<User>(users);
                await userRepository.DeleteRangeAsync<User>(users);

                foreach (var user in users)
                {
                    var deletedUser = userRepository.FindById<User>(user.Id);
                    deletedUser.Should().BeNull();
                }
            }
        }
    }
}