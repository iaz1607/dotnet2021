using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OnlineStoreApp.BLL.Implementation;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace StoreTests
{
    public class UserServicesTests
    {
        [Test]
        public async Task CreateAsyncUser()
        {
            // Arrange
            var expected = new User();
            var user = new User();

            var userDataAccess = new Mock<IUserDataAccess>();
            userDataAccess.Setup(x => x.InsertAsync(user)).ReturnsAsync(expected);
            var userCreateService = new UserCreateService(userDataAccess.Object);

            // Act
            var result = await userCreateService.CreateAsync(user);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task GetAsyncUser()
        {
            // Arrange
            var user = new User();
            user.userId = 1;
            var userId = new UserIdentityModel(user.userId);
            var userDataAccess = new Mock<IUserDataAccess>();
            userDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(user);
            var userGetService = new UserGetService(userDataAccess.Object);

            // Act
            var result = await userGetService.GetAsync(userId);

            // Assert
            result.Should().Be(user);
        }
    }
}