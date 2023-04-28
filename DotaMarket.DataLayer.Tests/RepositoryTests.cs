using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace DotaMarket.DataLayer.Tests
{
    public class RepositoryTests
    {
        private readonly Mock<DotaMarketContext> _contextMock;
        private readonly BaseRepository<User> _sut;
        private readonly UserHelper _userHelper;

        public RepositoryTests()
        {
            _contextMock = new Mock<DotaMarketContext>(new DbContextOptions<DotaMarketContext>());
            _userHelper = new UserHelper();
            _sut = new BaseRepository<User>(_contextMock.Object);
        }
      
        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            // Arrange
            var user = _userHelper.GetUser();

            _contextMock
                .Setup(x => x.Set<User>())
                .Returns(Mock.Of<DbSet<User>>);

            _contextMock
                .Setup(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<EntityEntry<User>>);

            //Act
            await _sut.AddAsync<User>(user);

            //Assert
            _contextMock.Verify(x => x.Set<User>(), Times.Once());
            _contextMock.Verify(x => x.Set<User>().AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
            _contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once());
            user.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleEntityFromDatabase()
        {
            // Arrange
            var user = _userHelper.GetUser();

            _contextMock
                .Setup(x => x.Set<User>())
                .Returns(Mock.Of<DbSet<User>>());

            _contextMock
                 .Setup(x => x.Remove(It.IsAny<User>()))
                 .Returns(Mock.Of<EntityEntry<User>>);

            // Act
            await _sut.DeleteAsync<User>(user);

            // Assert
            _contextMock.Verify(x => x.Set<User>(), Times.Once);
            _contextMock.Verify(x => x.Set<User>().Remove(user), Times.Once);
            _contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldAddEntitiesToDatabase()
        {
            // Arrange
            var users = _userHelper.GetUsers();

            _contextMock
                .Setup(x => x.Set<User>())
                .Returns(Mock.Of<DbSet<User>>());

            _contextMock
                .Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<User>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            await _sut.AddRangeAsync<User>(users);

            // Assert
            _contextMock.Verify(x => x.Set<User>(), Times.Once);
            _contextMock.Verify(x => x.Set<User>().AddRangeAsync(users, default), Times.Once);
            _contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);

            users.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldUpdateEntitiesInDatabase()
        {
            // Arrange
            var users = _userHelper.GetUsers();

            _contextMock
                 .Setup(x => x.Set<User>())
                 .Returns(Mock.Of<DbSet<User>>());
            _contextMock
                .Setup(x => x.Set<User>().UpdateRange(It.IsAny<IEnumerable<User>>()))
                .Verifiable();

            // Act
            users.Select(u => new User { Id = u.Id, Name = "Updated Name" });
            var result = await _sut.UpdateRangeAsync<User>(users);

            // Assert
            _contextMock.Verify(x => x.Set<User>(), Times.Once);
            _contextMock.Verify(x => x.Set<User>().UpdateRange(users), Times.Once);
            _contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);

            result.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task DeleteRangeAsync_ShouldDeleteEntitiesFromDatabase()
        {
            // Arrange
            var users = _userHelper.GetUsers();

            _contextMock
                .Setup(x => x.Set<User>())
                .Returns(Mock.Of<DbSet<User>>());
            _contextMock
                .Setup(x => x.Set<User>().RemoveRange(It.IsAny<IEnumerable<User>>()))
                .Verifiable();

            // Act
            await _sut.DeleteRangeAsync<User>(users);
            
            // Assert
            _contextMock.Verify(x => x.Set<User>(), Times.Once);
            _contextMock.Verify(x => x.Set<User>().RemoveRange(users), Times.Once);
            _contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

    }
}