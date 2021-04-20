using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.DAL.Contracts
{
    public interface IUserDataAccess
    {
        Task<User> InsertAsync(User user);
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(IUserIdentity userId);
        Task<User> UpdateAsync(UserUpdateModel user);
    }
}