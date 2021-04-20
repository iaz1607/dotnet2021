using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.DAL.Contracts
{
    public interface IItemDataAccess
    {
        Task<Item> InsertAsync(Item item);
        Task<IEnumerable<Item>> GetAsync();
        Task<Item> GetAsync(IItemIdentity itemId);
        Task<Item> GetAsync(int itemId);
        Task<Item> UpdateAsync(ItemUpdateModel item);
    }
}