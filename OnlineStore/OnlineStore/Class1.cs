using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace OnlineStore
{
    public class Bonus
    {
        private string bonusName;
        private int bonusDiscount;
    }
    public class User
    {
        private int accessLevel;
        private string userName;
        private long userId;
        private Bonus[] availableBonuses;
        private DateTime signUpDate;
        private double balance;
        private Cart userCart;
        private bool isAuthorized;
        public void UpdateUserInfo(Dictionary<string, string> info) 
        {

        }

        public Dictionary<string, string> GetUserInfo()
        {
            return null;
        }
    }

    public class Item
    {
        private string name;
        private long id;
        private double cost;
        private string type;
        private int count;

        public void Add(int n)
        {
            // increase item count in the store
        }
        public void Sub(int n)
        {
            // decrease item count in the store
        }
    }

    public class Cart
    {
        private Item[] cartItems;
        private long userId;
        public double TotalCost()
        {
            // return total cost of cart taking into account discounts
            return 0;
        }

        public void Buy()
        {
            // check if user has enough balance
            // check if we have enough items
            // decrease items count
            // decrease user balance
        }

        public void Add(long itemId)
        {
            // Add item into user cart
        }
    }

    public class Store
    {
        private User[] activeUsers;
        private Item[] items;

        public Store(User[] users, Item[] items)
        {
            activeUsers = users;
            this.items = items;
        }

        public User[] GetUsers()
        {
            return null;
        }

        public Item[] GetItems()
        {
            return null;
        }
    }

}
