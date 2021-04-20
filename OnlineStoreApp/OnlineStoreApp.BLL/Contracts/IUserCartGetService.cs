using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IUserCartGetService
    {
        Task<IEnumerable<UserCart>> GetAsync();

        Task<UserCart> GetAsync(IUserIdentity item);
    }
}