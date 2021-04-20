using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class ItemGetService : IItemGetService
    {
        private IItemDataAccess ItemDataAccess { get; }

        public ItemGetService(IItemDataAccess itemDataAccess)
        {
            this.ItemDataAccess = itemDataAccess;
        }

        public Task<IEnumerable<Item>> GetAsync()
        {
            return this.ItemDataAccess.GetAsync();
        }

        public Task<Item> GetAsync(IItemIdentity item)
        {
            return this.ItemDataAccess.GetAsync(item);
        }
    }
}