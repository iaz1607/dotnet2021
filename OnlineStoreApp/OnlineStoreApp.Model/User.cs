using System;
using System.Collections.Generic;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.Domain
{
    public class User
    {
        public int accessLevel { get; set; }
        public string userName { get; set; }
        public int userId { get; set; }
        public List<Bonus> availableBonuses { get; set; }
        public DateTime signUpDate { get; set; }
        public double balance { get; set; }
        public UserCart userCart { get; set; }
        public bool isAuthorized { get; set; }
    }
}