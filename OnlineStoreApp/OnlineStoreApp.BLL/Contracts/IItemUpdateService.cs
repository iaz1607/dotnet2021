using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IItemUpdateService
    {
        Task<Item> UpdateAsync(ItemUpdateModel item);
    }
}