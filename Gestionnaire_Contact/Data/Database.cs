using MySql.Data.MySqlClient;

namespace Gestionnaire_Contact.Data
{
    public class Database
    {
        private static Database _database = new Database();
        private MySqlConnection _connection; 
        public MySqlConnection Connection { get { return _connection; } }
        private Database() { 
            _connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=gestionnaire_contact");
        }
        public static Database GetDataBase()
        {
            return _database;
        }
    }
}
