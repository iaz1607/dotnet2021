using System.Collections.Generic;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class UserCartUpdateModel : IUserIdentity
    {
        public Dictionary<int, int> cartItems { get; set; }
        public int Id { get; set; }
        public Bonus choosenBonus { get; set; }
    }
}