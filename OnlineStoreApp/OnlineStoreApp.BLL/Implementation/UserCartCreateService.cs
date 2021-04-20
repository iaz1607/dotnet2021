using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserCartCreateService : IUserCartCreateService
    {
        private IUserCartDataAccess UserCartDataAccess { get; }

        public UserCartCreateService(IUserCartDataAccess userCartDataAccess)
        {
            this.UserCartDataAccess = userCartDataAccess;
        }
        public async Task<UserCart> CreateAsync(UserCart userCart)
        {
            return await this.UserCartDataAccess.InsertAsync(userCart);
        }
    }
}