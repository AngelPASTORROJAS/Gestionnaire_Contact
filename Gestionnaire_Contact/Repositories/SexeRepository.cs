using Gestionnaire_Contact.Data;
using Gestionnaire_Contact.Models;
using MySql.Data.MySqlClient;

namespace Gestionnaire_Contact.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SexeRepository : IRepository<SexeModel, string>
    {
        private MySqlConnection _connection;
        public SexeRepository()
        {
            _connection = Database.GetDataBase().Connection;
        }
        public void Add(SexeModel model)
        {
            using (MySqlCommand command = new MySqlCommand("INSERT INTO Sexe (sexe) VALUES (@sexe);", _connection))
            {
                command.Parameters.AddWithValue("@sexe", model.Sexe);
                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Source} : {exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void Delete(string id)
        {
            using (MySqlCommand command = new MySqlCommand("DELETE FROM Palette WHERE sexe = @sexe;", _connection))
            {
                try
                {
                    _connection.Open();
                    command.Parameters.AddWithValue("@sexe", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Source} : {exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<SexeModel> GetAll()
        {
            List<SexeModel> sexes = new List<SexeModel>();
            using (MySqlCommand command = new MySqlCommand("SELECT sexe FROM Sexe;", _connection))
            {
                try
                {
                    _connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // ligne par ligne
                        {
                            sexes.Add(new SexeModel
                            {
                                Sexe=reader.GetString("sexe")
                            });
                        }
                        reader.Close();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Source} : {exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
            return sexes;
        }

        public SexeModel GetById(string id)
        {
            SexeModel sexe = new SexeModel { };
            using (MySqlCommand command = new MySqlCommand($"SELECT sexe FROM Sexe WHERE sexe = {id};", _connection))
            {
                try
                {
                    _connection.Open();
                    command.Parameters.AddWithValue("@sexe", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sexe.Sexe = reader.GetString("sexe");
                        }
                        reader.Close();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Source} : {exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
            return sexe;
        }

        public void Update(SexeModel model, string id)
        {
            List<string> columnsToUpdate = new List<string>();
            columnsToUpdate.Add("sexe = @sexe");

            using (MySqlCommand command = new MySqlCommand($"UPDATE Parcelle SET {string.Join(", ", columnsToUpdate)} WHERE sexe = @id);", _connection))
            {
                command.Parameters.AddWithValue("@sexe", model.Sexe);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Source} : {exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
