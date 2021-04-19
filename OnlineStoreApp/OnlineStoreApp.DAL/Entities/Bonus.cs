namespace OnlineStoreApp.DAL.Entities
{
    public class Bonus : Entity
    {
        public int Id { get; set; }
        public string bonusName;
        public int bonusDiscount;

        public Entity FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddToDatabase()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromDatabase()
        {
            throw new System.NotImplementedException();
        }
    }
}