using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer.Tests
{
    public class BaseRepositoryTests
    {
        private readonly DbContextOptions<DotaMarketContext> _options;
        private readonly BaseRepository<User> _sut;
        private readonly CreateUser _createUser;

        public BaseRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DotaMarketContext>()
                 .UseInMemoryDatabase(databaseName: "TestDatabase")
                 .Options;

            _createUser = new CreateUser();
            _sut = new BaseRepository<User>(new DotaMarketContext(_options));
            InitializeDatabaseValues();
        }

        protected void InitializeDatabaseValues()
        {
            using (var context = new DotaMarketContext(_options))
            {
                var users = _createUser.CreateUsers();
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
        
        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();
            var user = users.First();

            using var context = new DotaMarketContext(_options);
            var _sut = new BaseRepository<User>(context);

            //Act
            await _sut.AddAsync<User>(user);
            var result = _sut.FindById<User>(user.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityInDatabase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();
            var user = users.First();
            using var context = new DotaMarketContext(_options);
            var _sut = new BaseRepository<User>(context);
            await _sut.AddAsync<User>(user);
            
            //Act
            user.Name = "Test1";
            _sut.UpdateAsync<User>(user);
            var result = _sut.FindById<User>(user.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveEntityFromDatabase()
        {
            //Arrange 
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();
            var user = users.First();

            using var context = new DotaMarketContext(_options);
            var _sut = new BaseRepository<User>(context);
            await _sut.AddAsync<User>(user);
            //Act
            await _sut.DeleteAsync<User>(user);
            var result = _sut.FindById<User>(user.Id);

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task FindById_ShouldReturnEntityFromDatabase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();
            var user = users.First();

            using var context = new DotaMarketContext(_options);
            var _sut = new BaseRepository<User>(context);
            await _sut.AddAsync<User>(user);

            //Act
            var result = _sut.FindById<User>(user.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldAddRangeEntitiesInDataBase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();

            using (var context = new DotaMarketContext(_options))
            {
                var _sut = new BaseRepository<User>(context);
                
                //Act
                var addUsers = await _sut.AddRangeAsync<User>(users);

                //Assert
                addUsers.Should().BeEquivalentTo(users);
                context.Users.Should().HaveCount(6);
            }
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldUpdateEntitiesInDatabase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();

            using (var context = new DotaMarketContext(_options))
            {
                var _sut = new BaseRepository<User>(context);
                var addUsers = await _sut.AddRangeAsync<User>(users);

                //Act
                foreach (var user in users)
                {
                    user.Name = "Updated Name";
                }

                _sut.UpdateRangeAsync<User>(users);

                //Assert
                foreach (var user in users)
                {
                    var updatedUser = _sut.FindById<User>(user.Id);
                    updatedUser.Should().NotBeNull();
                    updatedUser.Name.Should().Be("Updated Name");
                }
            }
        }

        [Fact]
        public async Task DeleteRangeAsync_ShouldRemoveEntitiesFromDatabase()
        {
            //Arrange
            var createUser = new CreateUser();
            var users = createUser.CreateUsers();

            using (var context = new DotaMarketContext(_options))
            {
                var _sut = new BaseRepository<User>(context);
                await _sut.AddRangeAsync<User>(users);
                //Act
                await _sut.DeleteRangeAsync<User>(users);

                //Assert
                foreach (var user in users)
                {
                    var deletedUser = _sut.FindById<User>(user.Id);
                    deletedUser.Should().BeNull();
                }
            }
        }     
    }  
    public class CreateUser
    {
        public List<User> CreateUsers()
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
    }
}