using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IUserCartUpdateService
    {
        Task<UserCart> UpdateAsync(UserCart user);
    }
}