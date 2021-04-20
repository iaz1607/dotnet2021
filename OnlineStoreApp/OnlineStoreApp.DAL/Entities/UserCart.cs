using System.Collections.Generic;

namespace OnlineStoreApp.DAL.Entities
{
    public class UserCart
    {
        private Dictionary<int, int> cartItems;
        private int userId;
        private Bonus choosenBonus;
    }
}