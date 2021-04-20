using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IUserCartServices
    {
        public void AddItem(Item item);
        public void BuyCart();
        public void Clear();
    }
}