using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using OnlineStoreApp.BLL;

namespace StoreTests
{
    public class Tests
    {
        private UserDomainModel userAdmin;
        private UserDomainModel commonUser;
        private List<ItemDomainModel> items;
        private List<BonusDomainModel> bonuses;

        [SetUp]
        public void Setup()
        {
            userAdmin = new UserDomainModel(accessLevel: 0, "admin", userId: 0, availableBonuses: null, signUpDate: DateTime.Now,
                balance: 10000, isAuthorized: true);
            commonUser = new UserDomainModel(accessLevel: 1, "iaz1607", userId: 1, availableBonuses: null, signUpDate: DateTime.Now, isAuthorized: true);
            items = new List<ItemDomainModel>();
            items.Add(new ItemDomainModel("Samsung Monitor 9000", 0, 20000, "monitor", 10));
            items.Add(new ItemDomainModel("xiaomi smartphone 3000", 1, 100, "smartphone", 1));
            items.Add(new ItemDomainModel("apple airpods pro 2", 2, 10000, "headphones", 2));

            bonuses = new List<BonusDomainModel>();
            bonuses.Add(new BonusDomainModel("new year", 50));
            bonuses.Add(new BonusDomainModel("christmas", 10));
        }

        [Test]
        public void TestUser()
        {
            Assert.AreEqual(commonUser.GetBalance(), 0);
            Assert.AreEqual(commonUser.GetUserCart().GetItems().Count, 0);
            commonUser.IncreaseBalance(100);
            Assert.AreEqual(commonUser.GetBalance(), 100);
            commonUser.DecreaseBalance(50);
            Assert.AreEqual(commonUser.GetBalance(), 50);
        }
        [Test]
        public void TestItem()
        {
            ItemDomainModel testItem = items[0];
            Assert.AreEqual(testItem.GetCost(), 20000);
            Assert.AreEqual(testItem.GetCount(), 10);
            testItem.Add(5);
            Assert.AreEqual(testItem.GetCount(), 15);
            testItem.Sub(3);
            Assert.AreEqual(testItem.GetCount(), 12);
            testItem.SetCost(15000);
            Assert.AreEqual(testItem.GetCost(), 15000);
        }

        [Test]
        public void TestCart()
        {
            CartDomainModel testCart = new CartDomainModel(commonUser);
            ItemDomainModel copyItem0 = items[0].Copy(1);
            ItemDomainModel copyItem1 = items[1].Copy(2);
            ItemDomainModel copyItem2 = items[2].Copy(3);

            testCart.Add(copyItem0);
            testCart.Add(copyItem2);

            Assert.AreEqual(testCart.TotalCost(), 50000);
            testCart.Add(copyItem1);
            Assert.AreEqual(testCart.TotalCost(), 50200);
        }
        [Test]
        public void TestStore()
        {
            StoreDomainModel testStore = new StoreDomainModel(new List<UserDomainModel> { userAdmin, commonUser }, items);
            testStore.AddBonus(bonuses[0]);
            testStore.AddBonus(bonuses[1]);

            testStore.AddItemIntoUserCart(commonUser, items[0].Copy(1));
            testStore.AddItemIntoUserCart(commonUser, items[1].Copy(1));
            testStore.AddItemIntoUserCart(commonUser, items[2].Copy(1));
            //test Buy when user have no enought money
            Assert.Throws<StoreDomainModel.NotEnoughMoneyException>(() => testStore.BuyCart(commonUser.GetUserId()));
            testStore.ChangeItemCountInUserCart(commonUser, commonUser.GetUserCart().GetItems()[1], 100);

            //test buy when we have not enough items in the store
            Assert.Throws<StoreDomainModel.NotEnoughItemsException>(() => testStore.BuyCart(commonUser.GetUserId()));
            testStore.ChangeItemCountInUserCart(commonUser, commonUser.GetUserCart().GetItems()[1], -100);
            commonUser.IncreaseBalance(100000);
            var BuyItems = commonUser.GetUserCart().GetItems();
            // test buy when all is ok
            Assert.AreEqual(testStore.BuyCart(commonUser.GetUserId()), BuyItems);

            testStore.AddItemIntoUserCart(commonUser, items[0].Copy(1));
            testStore.AddItemIntoUserCart(commonUser, items[1].Copy(1));
            testStore.AddItemIntoUserCart(commonUser, items[2].Copy(1));

            // test items count after buy
            Assert.Throws<StoreDomainModel.NotEnoughItemsException>(() => testStore.BuyCart(commonUser.GetUserId()));

            // test balance after buy
            Assert.AreEqual(commonUser.GetBalance(), 69900);

        }
    }
}