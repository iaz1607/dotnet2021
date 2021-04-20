using System.Collections.Generic;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain
{
    public class UserCart : IUserIdentity
    {
        public Dictionary<int, int> cartItems { get; set; }
        public int Id{ get; set; }
        public Bonus choosenBonus { get; set; }
    }
}