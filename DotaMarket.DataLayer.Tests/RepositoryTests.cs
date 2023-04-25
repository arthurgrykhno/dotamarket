using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer.Tests
{
    public class RepositoryTests
    {
        private readonly DotaMarketContext _context;
        private readonly BaseRepository<User> _sut;
        private readonly UserHelper _userHelper;
        
        public RepositoryTests()
        {  
           var options = new DbContextOptionsBuilder<DotaMarketContext>()
                 .UseInMemoryDatabase(databaseName: "TestDatabase")
                 .Options;
            _userHelper = new UserHelper();
            _context = new DotaMarketContext(options);
            _sut = new BaseRepository<User>(_context);

            InitializeDatabaseValues();
        }
    
        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            //Arrange
            var user = _userHelper.GetUser();

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
            var user = _userHelper.GetUser();
            await _sut.AddAsync<User>(user);
            user.Name = "Test1";

            //Act
            await _sut.UpdateAsync<User>(user);
            var result = _sut.FindById<User>(user.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

            [Fact]
        public async Task DeleteAsync_ShouldRemoveEntityFromDatabase()
        {
            //Arrange 
            var user = _userHelper.GetUser();
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
            var user = _userHelper.GetUser();
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
            // Arrange
            var users = _userHelper.GetUsers();

            // Act
            var addedUsers = await _sut.AddRangeAsync<User>(users);

            // Assert
            addedUsers.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldUpdateEntitiesInDatabase()
        {
            //Arrange
            var users = _userHelper.GetUsers();
            await _sut.AddRangeAsync<User>(users);

            //Act
            foreach (var user in users)
            {
                user.Name = "Updated Name";
            }

            await _sut.UpdateRangeAsync<User>(users);

            //Assert
            foreach (var user in users)
            {
                var updatedUser = _sut.FindById<User>(user.Id);
                updatedUser.Should().NotBeNull();
                updatedUser.Name.Should().Be("Updated Name");
            }
        }

        [Fact]
        public async Task DeleteRangeAsync_ShouldRemoveEntitiesFromDatabase()
        {
            //Arrange
            var users = _userHelper.GetUsers();
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

        private void InitializeDatabaseValues()
        {
            var users = _userHelper.GetUser();
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
    }  
}