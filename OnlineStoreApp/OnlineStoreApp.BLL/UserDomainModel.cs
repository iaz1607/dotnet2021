using System;
using System.Collections.Generic;

namespace OnlineStoreApp.BLL
{
    public class UserDomainModel
    {
        private int accessLevel;
        private string userName;
        private long userId;
        private List<BonusDomainModel> availableBonuses;
        private DateTime signUpDate;
        private double balance;
        private CartDomainModel userCart;
        private bool isAuthorized;

        public UserDomainModel(
            int accessLevel = 0,
            string userName = "",
            long userId = 0,
            List<BonusDomainModel> availableBonuses = default(List<BonusDomainModel>),
            DateTime signUpDate = default(DateTime),
            double balance = 0,
            CartDomainModel userCart = null,
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
                this.userCart = new CartDomainModel(this);
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

        public CartDomainModel GetUserCart()
        {
            return userCart;
        }

        public void AddBonus(BonusDomainModel bonus)
        {
            availableBonuses.Add(bonus);
        }

        public void UpdateUserInfo(Dictionary<string, object> info)
        {
            accessLevel = (int)info["accessLevel"];
            userName = (string)info["userName"];
            userId = (long)info["userId"];
            availableBonuses = (List<BonusDomainModel>)info["availableBonuses"];
            signUpDate = (DateTime)info["signUpDate"];
            balance = (double)info["balance"];
            userCart = (CartDomainModel)info["userCart"];
            isAuthorized = (bool)info["isAuthorized"];
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
}