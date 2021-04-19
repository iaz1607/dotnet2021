namespace OnlineStoreApp.DAL.Entities
{
    public class Item : Entity
    {
        public int Id { get; set; }
        private string name;
        private long id;
        private double cost;
        private string type;
        private int count;

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