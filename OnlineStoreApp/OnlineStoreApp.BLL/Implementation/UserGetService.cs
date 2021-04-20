using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserGetService
    {
        private IUserDataAccess UserDataAccess { get; }

        public UserGetService(IUserDataAccess userDataAccess)
        {
            this.UserDataAccess = userDataAccess;
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            return this.UserDataAccess.GetAsync();
        }

        public Task<User> GetAsync(IUserIdentity user)
        {
            return this.UserDataAccess.GetAsync(user);
        }
    }
}