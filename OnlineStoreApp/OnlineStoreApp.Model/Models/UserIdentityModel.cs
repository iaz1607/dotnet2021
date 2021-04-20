using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class UserIdentityModel : IUserIdentity
    {
        public int Id { get; }

        public UserIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}