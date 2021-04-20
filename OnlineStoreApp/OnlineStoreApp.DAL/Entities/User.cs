using System;
using System.Collections.Generic;

namespace OnlineStoreApp.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        private int accessLevel;
        private string userName;
        private List<Bonus> availableBonuses;
        private DateTime signUpDate;
        private double balance;
    }
}