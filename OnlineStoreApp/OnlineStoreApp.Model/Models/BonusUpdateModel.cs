using OnlineStoreApp.Domain.Contracts;

namespace OnlineStoreApp.Domain.Models
{
    public class BonusUpdateModel : IBonusIdentity
    {
        public int Id { get; set; }
        public string bonusName { get; set; }
        public int bonusDiscount { get; set; }
    }
}