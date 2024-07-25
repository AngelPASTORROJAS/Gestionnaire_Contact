namespace Gestionnaire_Contact.Repositories
{
    public interface IRepository<T, TKey> // CRUD
    {
        T GetById(TKey id);         // Read by id
        IEnumerable<T> GetAll();    // Read all
        void Add(T model);           // Create
        void Update(T model);        // Update
        void Delete(T model);        // Delete
    }
}
