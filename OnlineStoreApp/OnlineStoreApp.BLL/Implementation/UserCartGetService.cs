using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserCartGetService : IUserCartGetService
    {
        private IUserCartDataAccess UserCartDataAccess { get; }

        public UserCartGetService(IUserCartDataAccess userCartDataAccess)
        {
            this.UserCartDataAccess = userCartDataAccess;
        }

        public Task<IEnumerable<UserCart>> GetAsync()
        {
            return this.UserCartDataAccess.GetAsync();
        }

        public Task<UserCart> GetAsync(IUserIdentity userId)
        {
            return this.UserCartDataAccess.GetAsync(userId);
        }
    }
}