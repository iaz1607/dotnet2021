using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OnlineStoreApp.BLL;
using OnlineStoreApp.BLL.Implementation;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace StoreTests
{
    public class UserCartServiceTests
    {
        [Test]
        public async Task UserCartServicesBuy()
        {
            var user = new User();
            user.balance = 10000;
            user.userId = 1;
            var userId = new UserIdentityModel(user.userId);
            var item1 = new Item();
            item1.cost = 100;
            item1.id = 1;

            var item2 = new Item();
            item2.cost = 200;
            item2.id = 2;

            var item3 = new Item();
            item3.cost = 300;
            item3.id = 3;

            var userCart = new UserCart();
            userCart.cartItems = new Dictionary<int, int>();
            userCart.cartItems[1] = 1;
            userCart.cartItems[2] = 2;
            userCart.cartItems[3] = 3;

            var userDataAccess = new Mock<IUserDataAccess>();
            var userCartDataAccess = new Mock<IUserCartDataAccess>();
            var itemDataAccess = new Mock<IItemDataAccess>();
            userDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(user);
            userCartDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(userCart);
            itemDataAccess.Setup(x => x.GetAsync(item1.id)).ReturnsAsync(item1);
            itemDataAccess.Setup(x => x.GetAsync(item2.id)).ReturnsAsync(item2);
            itemDataAccess.Setup(x => x.GetAsync(item3.id)).ReturnsAsync(item3);
            var userCartServices = new UserCartServices(userId, userDataAccess.Object, itemDataAccess.Object, userCartDataAccess.Object);
            userCartServices.BuyCart();
            userCartServices.User.balance.Should().Be(8600);
        }

        [Test]
        public async Task UserCartServicesClean()
        {
            // Arrange
            var user = new User();
            user.balance = 10000;
            user.userId = 1;
            var userId = new UserIdentityModel(user.userId);
            var item1 = new Item();
            item1.cost = 100;
            item1.id = 1;

            var item2 = new Item();
            item2.cost = 200;
            item2.id = 2;

            var item3 = new Item();
            item3.cost = 300;
            item3.id = 3;

            var userCart = new UserCart();
            userCart.cartItems = new Dictionary<int, int>();
            userCart.cartItems[1] = 1;
            userCart.cartItems[2] = 2;
            userCart.cartItems[3] = 3;

            var userDataAccess = new Mock<IUserDataAccess>();
            var userCartDataAccess = new Mock<IUserCartDataAccess>();
            var itemDataAccess = new Mock<IItemDataAccess>();
            userDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(user);
            userCartDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(userCart);
            itemDataAccess.Setup(x => x.GetAsync(item1.id)).ReturnsAsync(item1);
            itemDataAccess.Setup(x => x.GetAsync(item2.id)).ReturnsAsync(item2);
            itemDataAccess.Setup(x => x.GetAsync(item3.id)).ReturnsAsync(item3);
            var userCartServices = new UserCartServices(userId, userDataAccess.Object, itemDataAccess.Object, userCartDataAccess.Object);

            userCartServices.User.userCart.cartItems.Count.Should().Be(3);

            userCartServices.Clear();

            userCartServices.User.userCart.cartItems.Count.Should().Be(0);
            userCartServices.User.userCart.choosenBonus.Should().Be(null);
        }

        [Test]
        public async Task UserCartServicesAdd()
        {
            // Arrange
            var user = new User();
            user.balance = 10000;
            user.userId = 1;
            var userId = new UserIdentityModel(user.userId);
            var item1 = new Item();
            item1.cost = 100;
            item1.id = 1;

            var item2 = new Item();
            item2.cost = 200;
            item2.id = 2;

            var item3 = new Item();
            item3.cost = 300;
            item3.id = 3;

            var userCart = new UserCart();

            var userDataAccess = new Mock<IUserDataAccess>();
            var userCartDataAccess = new Mock<IUserCartDataAccess>();
            var itemDataAccess = new Mock<IItemDataAccess>();
            userDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(user);
            userCartDataAccess.Setup(x => x.GetAsync(userId)).ReturnsAsync(userCart);
            itemDataAccess.Setup(x => x.GetAsync(item1.id)).ReturnsAsync(item1);
            itemDataAccess.Setup(x => x.GetAsync(item2.id)).ReturnsAsync(item2);
            itemDataAccess.Setup(x => x.GetAsync(item3.id)).ReturnsAsync(item3);
            var userCartServices = new UserCartServices(userId, userDataAccess.Object, itemDataAccess.Object, userCartDataAccess.Object);
            userCartServices.AddItem(item1);
            userCartServices.AddItem(item2);
            userCartServices.AddItem(item3);

            userCartServices.User.userCart.cartItems.Count.Should().Be(3);
        }

    }
}