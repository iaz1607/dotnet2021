namespace OnlineStoreApp.Domain
{
    public class Bonus
    {
        public string bonusName { get; set; }
        public int bonusDiscount { get; set; }
        public Bonus(string name, int discount)
        {
            bonusDiscount = discount;
            bonusName = name;
        }
    }
}