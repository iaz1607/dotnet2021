using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class ItemUpdateService : IItemUpdateService
    {
        private IItemDataAccess ItemDataAccess { get; }

        public ItemUpdateService(IItemDataAccess itemDataAccess)
        {
            this.ItemDataAccess = itemDataAccess;
        }

        public async Task<Item> UpdateAsync(ItemUpdateModel item)
        {
            return await this.ItemDataAccess.UpdateAsync(item);
        }
    }
}