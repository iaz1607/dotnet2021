using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IUserGetService
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(IUserIdentity user);
    }
}