namespace OnlineStoreApp.BLL
{
    public class ItemDomainModel
    {
        private string name;
        private long id;
        private double cost;
        private string type;
        private int count;

        public ItemDomainModel(string itemName = "", long itemId = 0, double itemCost = 0, string itemType = "common", int itemCount = 0)
        {
            name = itemName;
            id = itemId;
            cost = itemCost;
            type = itemType;
            count = itemCount;
        }

        public ItemDomainModel Copy(int count)
        {
            return new ItemDomainModel(name, id, cost, type, count);
        }
        public string GetType()
        {
            return type;
        }

        public string GetName()
        {
            return name;
        }
        public double GetCost()
        {
            return cost;
        }

        public void SetCost(double newCost)
        {
            cost = newCost;
        }

        public void Add(int n)
        {
            this.count += n;
        }

        public void Sub(int n)
        {
            this.count -= n;
        }

        public int GetCount()
        {
            return count;
        }

        public long GetId()
        {
            return id;
        }
    }
}