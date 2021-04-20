using System.Threading.Tasks;
using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserCreateService : IUserCreateService
    {
        private IUserDataAccess UserDataAccess { get; }

        public UserCreateService(IUserDataAccess userDataAccess)
        {
            this.UserDataAccess = userDataAccess;
        }
        public async Task<User> CreateAsync(User user)
        {
            return await this.UserDataAccess.InsertAsync(user);
        }
    }
}