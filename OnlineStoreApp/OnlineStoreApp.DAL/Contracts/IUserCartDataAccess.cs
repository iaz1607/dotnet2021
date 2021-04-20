using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.DAL.Contracts
{
    public interface IUserCartDataAccess
    {
        Task<UserCart> InsertAsync(UserCart userCart);
        Task<IEnumerable<UserCart>> GetAsync();
        Task<UserCart> GetAsync(IUserIdentity userId);
        Task<UserCart> UpdateAsync(UserCart userCart);
    }
}