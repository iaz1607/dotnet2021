using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace OnlineStore
{
    public class Bonus
    {
        public string bonusName;
        public int bonusDiscount;

        public Bonus(string name, int discount)
        {
            bonusDiscount = discount;
            bonusName = name;
        }
    }
    public class User
    {
        private int accessLevel;
        private string userName;
        private long userId;
        private List<Bonus> availableBonuses;
        private DateTime signUpDate;
        private double balance;
        private Cart userCart;
        private bool isAuthorized;

        public User(
            int accessLevel = 0,
            string userName = "",
            long userId = 0,
            List<Bonus> availableBonuses = default(List<Bonus>),
            DateTime signUpDate = default(DateTime),
            double balance = 0,
            Cart userCart = null,
            bool isAuthorized = false
        )
        {
            this.accessLevel = accessLevel;
            this.userName = userName;
            this.userId = userId;
            this.availableBonuses = availableBonuses;
            this.signUpDate = signUpDate;
            this.balance = balance;
            if (userCart == null)
            {
                this.userCart = new Cart(this);
            }
            else
            {
                this.userCart = userCart;
            }

            this.isAuthorized = isAuthorized;
        }

        public void DecreaseBalance(double delta)
        {
            this.balance -= delta;
        }

        public void IncreaseBalance(double delta)
        {
            this.balance += delta;
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetUserName()
        {
            return userName;
        }

        public long GetUserId()
        {
            return userId;
        }

        public Cart GetUserCart()
        {
            return userCart;
        }

        public void AddBonus(Bonus bonus)
        {
            availableBonuses.Add(bonus);
        }

        public void UpdateUserInfo(Dictionary<string, object> info)
        {
            accessLevel = (int)info["accessLevel"];
            userName = (string)info["userName"];
            userId = (long)info["userId"];
            availableBonuses = (List<Bonus>) info["availableBonuses"];
            signUpDate = (DateTime)info["signUpDate"];
            balance = (double)info["balance"];
            userCart = (Cart)info["userCart"];
            isAuthorized = (bool) info["isAuthorized"];
        }

        public Dictionary<string, object> GetUserInfo()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("accessLevel", accessLevel);
            result.Add("userName", userName);
            result.Add("userId", userId);
            result.Add("availableBonuses", availableBonuses);
            result.Add("signUpDate", signUpDate);
            result.Add("balance", balance);
            result.Add("userCart", userCart);
            result.Add("isAuthorize", isAuthorized);
            return result;
        }

    }

    public class Item
    {
        private string name;    
        private long id;
        private double cost;
        private string type;
        private int count;

        public Item(string itemName = "", long itemId = 0, double itemCost = 0, string itemType = "common", int itemCount = 0)
        {
            name = itemName;
            id = itemId;
            cost = itemCost;
            type = itemType;
            count = itemCount;
        }

        public Item Copy(int count)
        {
            return new Item(name, id, cost, type, count);
        }
        public string GetType()
        {
            return type;
        }

        public string GetName()
        {
            return name;
        }
        public double GetCost()
        {
            return cost;
        }

        public void SetCost(double newCost)
        {
            cost = newCost;
        }

        public void Add(int n)
        {
            this.count += n;
        }

        public void Sub(int n)
        {
            this.count -= n;
        }

        public int GetCount()
        {
            return count;
        }

        public long GetId()
        {
            return id;
        }
    }

    public class Cart
    {
        private List<Item> cartItems;
        private long userId;
        private Bonus choosenBonus;

        public Cart(User cartUser)
        {
            choosenBonus = null;
            userId = cartUser.GetUserId();
            cartItems = new List<Item>();
        }
        public void SetBonus(Bonus bonus)
        {
            this.choosenBonus = bonus;
        }
        public double TotalCost()
        {
            double totalCost = 0;
            for (int i = 0; i < cartItems.Count; ++i)
            {
                totalCost += cartItems[i].GetCount() * cartItems[i].GetCost();
            }

            if (choosenBonus != null)
            {
                return totalCost * (100 - choosenBonus.bonusDiscount) / 100;
            }
            else
            {
                return totalCost;
            }
        }

        public void Add(Item item)
        {
            cartItems.Add(item);
        }

        public void IncreaseItemCount(long itemId, int inc)
        {
            for (int i = 0; i < cartItems.Count; ++i)
            {
                if (cartItems[i].GetId() == itemId)
                {
                    cartItems[i].Add(inc);
                }
            }
        }

        public void DecreaseItemCount(long itemId, int dec)
        {
            for (int i = 0; i < cartItems.Count; ++i)
            {
                if (cartItems[i].GetId() == itemId)
                {
                    cartItems[i].Add(dec);
                }
            }
        }

        public long GetUserId()
        {
            return userId;
        }

        public List<Item> GetItems()
        {
            return cartItems;
        }

        public void Clear()
        {
            choosenBonus = null;
            cartItems.Clear();
        }
    }

    public class Store
    {
        public class NotEnoughMoneyException : Exception
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
        private Dictionary<long, User> activeUsers;
        private Dictionary<long, Item> items;
        private List<Bonus> storeBonuses;

        public Store(List<User> users, List<Item> items)
        {
            storeBonuses = new List<Bonus>();
            this.activeUsers = new Dictionary<long, User>();
            this.items = new Dictionary<long, Item>();
            foreach (var user in users)
            {
                activeUsers[user.GetUserId()] = user;
            }

            foreach (var item in items)
            {
                this.items[item.GetId()] = item;
            }
        }

        public Dictionary<long, User> GetUsers()
        {
            return activeUsers;
        }

        public Dictionary<long, Item> GetItems()
        {
            return items;
        }

        public void AddUser(User user)
        {
            activeUsers[user.GetUserId()] = user;
        }

        public bool IsUserLogedIn(User user)
        {
            return activeUsers.ContainsKey(user.GetUserId());
        }

        public void RemoveUser(User user)
        {
            activeUsers.Remove(user.GetUserId());
        }

        public void AddItem(Item item)
        {
            items[item.GetId()] = item;
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item.GetId());
        }

        public void ChangeItemCount(Item item, int delta)
        {
            items[item.GetId()].Add(delta);
        }

        public void ChangeItemCost(Item item, double newCost)
        {
            items[item.GetId()].SetCost(newCost);
        }

        public void AddItemIntoUserCart(User user, Item item)
        {
            user.GetUserCart().Add(item);
        }

        public void ChangeItemCountInUserCart(User user, Item item, int delta)
        {
            activeUsers[user.GetUserId()].GetUserCart().IncreaseItemCount(item.GetId(), delta);
        }

        public void AddBonus(Bonus newBonus)
        {
            storeBonuses.Add(newBonus);
        }

        public List<Item> BuyCart(long userId)
        {
            User currentUser = activeUsers[userId];
            Cart currentUserCart = currentUser.GetUserCart();
            double cartCost = currentUserCart.TotalCost();
            double userBalance = currentUser.GetBalance();
            List<Item> buyingItems = currentUserCart.GetItems();

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

        private void DecreaseItems(List<Item> buyingItems)
        {
            foreach (var item in buyingItems)
            {
                items[item.GetId()].Sub(item.GetCount());
            }
        }

        private bool IsEnoughItems(List<Item> buyingItems)
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
