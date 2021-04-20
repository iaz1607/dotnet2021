using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class ItemCreateService : IItemCreateService
    {
        private IItemDataAccess ItemDataAccess { get; }

        public ItemCreateService(IItemDataAccess itemDataAccess)
        {
            this.ItemDataAccess = itemDataAccess;
        }
        public async Task<Item> CreateAsync(Item item)
        {
            return await this.ItemDataAccess.InsertAsync(item);
        }
    }
}