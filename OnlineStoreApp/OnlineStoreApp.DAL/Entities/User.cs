using System;
using System.Collections.Generic;

namespace OnlineStoreApp.DAL.Entities
{
    public class User : Entity
    {
        public int Id { get; set; }
        private int accessLevel;
        private string userName;
        private List<Bonus> availableBonuses;
        private DateTime signUpDate;
        private double balance;

        public Entity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddToDatabase()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromDatabase()
        {
            throw new NotImplementedException();
        }
    }
}