using System;
using System.Collections.Generic;

namespace OnlineStoreApp.BLL
{
    public class StoreDomainModel
    {
        public class NotEnoughMoneyException : System.Exception
        {
            public NotEnoughMoneyException() : base()
            {

            }

            public NotEnoughMoneyException(string message) : base(message)
            {

            }

            public NotEnoughMoneyException(string message, Exception inner) : base(message, inner)
            {

            }
        }
        public class NotEnoughItemsException : Exception
        {
            public NotEnoughItemsException()
            {
            }

            public NotEnoughItemsException(string message) : base(message)
            {
            }

            public NotEnoughItemsException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
        private Dictionary<long, UserDomainModel> activeUsers;
        private Dictionary<long, ItemDomainModel> items;
        private List<BonusDomainModel> storeBonuses;
        
        public StoreDomainModel(List<UserDomainModel> users, List<ItemDomainModel> items)
        {
            storeBonuses = new List<BonusDomainModel>();
            this.activeUsers = new Dictionary<long, UserDomainModel>();
            this.items = new Dictionary<long, ItemDomainModel>();
            foreach (var user in users)
            {
                activeUsers[user.GetUserId()] = user;
            }

            foreach (var item in items)
            {
                this.items[item.GetId()] = item;
            }
        }

        public Dictionary<long, UserDomainModel> GetUsers()
        {
            return activeUsers;
        }

        public Dictionary<long, ItemDomainModel> GetItems()
        {
            return items;
        }

        public void AddUser(UserDomainModel user)
        {
            activeUsers[user.GetUserId()] = user;
        }

        public bool IsUserLogedIn(UserDomainModel user)
        {
            return activeUsers.ContainsKey(user.GetUserId());
        }

        public void RemoveUser(UserDomainModel user)
        {
            activeUsers.Remove(user.GetUserId());
        }

        public void AddItem(ItemDomainModel item)
        {
            items[item.GetId()] = item;
        }

        public void RemoveItem(ItemDomainModel item)
        {
            items.Remove(item.GetId());
        }

        public void ChangeItemCount(ItemDomainModel item, int delta)
        {
            items[item.GetId()].Add(delta);
        }

        public void ChangeItemCost(ItemDomainModel item, double newCost)
        {
            items[item.GetId()].SetCost(newCost);
        }

        public void AddItemIntoUserCart(UserDomainModel user, ItemDomainModel item)
        {
            user.GetUserCart().Add(item);
        }

        public void ChangeItemCountInUserCart(UserDomainModel user, ItemDomainModel item, int delta)
        {
            activeUsers[user.GetUserId()].GetUserCart().IncreaseItemCount(item.GetId(), delta);
        }

        public void AddBonus(BonusDomainModel newBonus)
        {
            storeBonuses.Add(newBonus);
        }

        public List<ItemDomainModel> BuyCart(long userId)
        {
            UserDomainModel currentUser = activeUsers[userId];
            CartDomainModel currentUserCart = currentUser.GetUserCart();
            double cartCost = currentUserCart.TotalCost();
            double userBalance = currentUser.GetBalance();
            List<ItemDomainModel> buyingItems = currentUserCart.GetItems();

            if (cartCost <= userBalance && IsEnoughItems(buyingItems))
            {
                currentUser.DecreaseBalance(cartCost);
                DecreaseItems(buyingItems);
                currentUserCart.Clear();
                return buyingItems;
            }
            else if (!IsEnoughItems(buyingItems))
            {
                throw new NotEnoughItemsException("Not enough items in store.");
            }
            else
            {
                throw new NotEnoughMoneyException(String.Format(
                    "You have not enough money for buy this Cart. Yor balance: {0}, cart cost: {1}",
                    userBalance, cartCost));
            }

        }

        private void DecreaseItems(List<ItemDomainModel> buyingItems)
        {
            foreach (var item in buyingItems)
            {
                items[item.GetId()].Sub(item.GetCount());
            }
        }

        private bool IsEnoughItems(List<ItemDomainModel> buyingItems)
        {
            foreach (var item in buyingItems)
            {
                if (items[item.GetId()].GetCount() < item.GetCount())
                {
                    return false;
                }
            }

            return true;

        }

    }
}
}