namespace OnlineStoreApp.DAL.Entities
{
    public interface Entity
    {
        int Id { get; set; }

        Entity FindById(int id);
        void AddToDatabase();
        void RemoveFromDatabase();
    }
}