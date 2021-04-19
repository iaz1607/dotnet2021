namespace OnlineStoreApp.BLL
{
    public class BonusDomainModel
    {
        public string bonusName;
        public int bonusDiscount;
        public BonusDomainModel(string name, int discount)
        {
            bonusDiscount = discount;
            bonusName = name;
        }
    }
}