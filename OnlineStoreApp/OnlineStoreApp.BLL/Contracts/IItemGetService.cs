using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IItemGetService
    {
        Task<IEnumerable<Item>> GetAsync();

        Task<Item> GetAsync(IItemIdentity item);
    }
}