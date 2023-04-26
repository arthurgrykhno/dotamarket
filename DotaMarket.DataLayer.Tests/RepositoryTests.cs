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
    }  
}