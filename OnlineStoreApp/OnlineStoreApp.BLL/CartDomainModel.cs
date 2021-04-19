using System.Collections.Generic;

namespace OnlineStoreApp.BLL
{
    public class CartDomainModel
    {
        private List<ItemDomainModel> cartItems;
        private long userId;
        private BonusDomainModel choosenBonus;

        public Cart(UserDomainModel cartUser)
        {
            choosenBonus = null;
            userId = cartUser.GetUserId();
            cartItems = new List<ItemDomainModel>();
        }
        public void SetBonus(BonusDomainModel bonus)
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

        public void Add(ItemDomainModel item)
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

        public List<ItemDomainModel> GetItems()
        {
            return cartItems;
        }

        public void Clear()
        {
            choosenBonus = null;
            cartItems.Clear();
        }
    }