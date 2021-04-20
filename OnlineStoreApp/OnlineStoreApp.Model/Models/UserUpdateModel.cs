using System;
using System.Collections.Generic;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class UserUpdateModel : IUserIdentity
    {
        public int accessLevel { get; set; }
        public string userName { get; set; }
        public long Id { get; set; }
        public List<Bonus> availableBonuses { get; set; }
        public double balance { get; set; }
        public UserUpdateModel(User user)
        {
            accessLevel = user.accessLevel;
            userName = user.userName;
            Id = user.userId;
            availableBonuses = user.availableBonuses;
            balance = user.balance;
        }

        public UserUpdateModel()
        {

        }
    }
}