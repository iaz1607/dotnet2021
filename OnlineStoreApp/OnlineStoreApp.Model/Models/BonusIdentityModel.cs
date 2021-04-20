using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class BonusIdentityModel : IBonusIdentity
    {
        public int Id { get; }

        public BonusIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}