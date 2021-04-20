using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class ItemUpdateModel : IItemIdentity
    {
        public long id { get; set; }
        public double cost { get; set; }
        public int count { get; set; }
    }
}