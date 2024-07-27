using Gestionnaire_Contact.Data;
using Gestionnaire_Contact.Models;
using MySql.Data.MySqlClient;

namespace Gestionnaire_Contact.Repositories
{
    public class ContactRepository : IRepository<ContactModel, string>
    {
        private MySqlConnection _connection;
        public ContactRepository()
        {
            _connection = Database.GetDataBase().Connection; // key connection
        }
        public void Add(ContactModel model)
        {
            _connection.Open();                     // Je me connecte
                                                    // Je 
        }
        public void Update(ContactModel model, string id)
        { 
        }
        public void Delete(string id) 
        {
        }
        public IEnumerable<ContactModel> GetAll() 
        {
            return null;
        }
        public ContactModel GetById(string id) 
        { 
            return null;
        }
    }
}
