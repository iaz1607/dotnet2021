using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class ItemIdentityModel : IItemIdentity
    {
        public int Id { get; }

        public ItemIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}