using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserCartUpdateService : IUserCartUpdateService
    {
        private IUserCartDataAccess UserCartDataAccess { get; }

        public UserCartUpdateService(IUserCartDataAccess userCartDataAccess)
        {
            this.UserCartDataAccess = userCartDataAccess;
        }

        public async Task<UserCart> UpdateAsync(UserCart userCart)
        {
            return await this.UserCartDataAccess.UpdateAsync(userCart);
        }
    }
}