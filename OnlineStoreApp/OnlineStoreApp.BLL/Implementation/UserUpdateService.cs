using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.BLL.Implementation
{
    public class UserUpdateService
    {
        private IUserDataAccess UserDataAccess { get; }

        public UserUpdateService(IUserDataAccess userDataAccess)
        {
            this.UserDataAccess = userDataAccess;
        }

        public async Task<User> UpdateAsync(UserUpdateModel item)
        {
            return await this.UserDataAccess.UpdateAsync(item);
        }
    }
}