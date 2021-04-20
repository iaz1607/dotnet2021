using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.DAL.Implementation;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserCartServices : IUserCartServices
    {
        public User User { get; }
        private IUserDataAccess UserDataAccess { get; }
        private IUserCartDataAccess UserCartDataAccess { get; }
        private IItemDataAccess ItemDataAccess { get; }
        public UserCartServices(IUserIdentity userId, IUserDataAccess userDataAccess, IItemDataAccess itemDataAccess, IUserCartDataAccess userCartDataAccess)
        {
            UserDataAccess = userDataAccess;
            UserCartDataAccess = userCartDataAccess;
            ItemDataAccess = itemDataAccess;
            User = userDataAccess.GetAsync(userId).Result;
            User.userCart = userCartDataAccess.GetAsync(userId).Result;
            if (User.userCart == null)
                User.userCart = userCartDataAccess.InsertAsync(new UserCart()).Result;
        }
        public async void AddItem(Item item)
        {
            if (!User.userCart.cartItems.ContainsKey(item.id))
            {
                User.userCart.cartItems[item.id] = 0;
            }
            User.userCart.cartItems[item.id]++;
            await UserCartDataAccess.UpdateAsync(User.userCart);
        }

        public async void BuyCart()
        {
            // calculate cart cost
            double cartCost = 0;

            foreach (var kv in User.userCart.cartItems)
            {
                cartCost += ItemDataAccess.GetAsync(kv.Key).Result.cost * kv.Value;
            }

            Clear();
            User.balance -= cartCost;

            await UserCartDataAccess.UpdateAsync(User.userCart);
            await UserDataAccess.UpdateAsync(new UserUpdateModel(User));
        }

        public async void Clear()
        {
            User.userCart.cartItems.Clear();
            User.userCart.choosenBonus = null;
            await UserCartDataAccess.UpdateAsync(User.userCart);
        }
    }
}