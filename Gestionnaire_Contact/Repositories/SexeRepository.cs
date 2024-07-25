using Gestionnaire_Contact.Data;
using Gestionnaire_Contact.Models;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Gestionnaire_Contact.Repositories
{
    public class SexeRepository : IRepository<SexeModel, string>
    {
        private MySqlConnection _connection;
        public SexeRepository()
        {
            _connection = Database.GetDataBase().Connection;
        }
        public void Add(SexeModel model)
        {
            using (MySqlCommand command = new MySqlCommand("INSERT INTO Parcelle (no_parcelle, surface, nom_parcelle, coordonnees) VALUES (@no_parcelle, @surface, @nom_parcelle, @coordonnees);", _connection))
            {
                command.Parameters.AddWithValue("@no_parcelle", entity.NoParcelle);
                command.Parameters.AddWithValue("@surface", entity.Surface);
                command.Parameters.AddWithValue("@nom_parcelle", entity.NomParcelle);
                command.Parameters.AddWithValue("@coordonnees", entity.Coordonnees);
                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new RepositoryException($"Erreur lors de l'ajout de la parcelle.", nameof(ParcelleRepository), "Add", exception);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void Delete(SexeModel model)
        {
            using (MySqlCommand command = new MySqlCommand("DELETE FROM Palette WHERE no_parcelle = @no_parcelle;", _connection))
            {
                try
                {
                    _connection.Open();
                    command.Parameters.AddWithValue("@no_parcelle", id);

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("L'unité a supprimer n'as pas pu être trouver.");
                    }
                }
                catch (Exception exception)
                {
                    throw new RepositoryException($"Erreur lors de la suppression de la parcelle.", nameof(ParcelleRepository), "Delete", exception);
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
                    Console.WriteLine(exception);
                }
                finally
                {
                    _connection.Close();
                }
            }
            return sexes;
        }

        public SexeModel GetById(string id) // "M"
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
                    Console.WriteLine($"{exception.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
            return sexe!;
        }

        public void Update(SexeModel model)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.NoParcelle == null)
                throw new ArgumentNullException(nameof(entity));

            List<string> columnsToUpdate = new List<string>();
            if (entity.NomParcelle == null)
                columnsToUpdate.Add("nom_parcelle = @NomParcelle");
            if (entity.Surface == null)
                columnsToUpdate.Add("surface = @Surface");
            if (entity.Coordonnees == null)
                columnsToUpdate.Add("coordonnees = @Coordonnees");

            using (MySqlCommand command = new MySqlCommand($"UPDATE Parcelle SET {string.Join(", ", columnsToUpdate)} WHERE no_parcelle=@NoParcelle);", _connection))
            {
                command.Parameters.AddWithValue("@NoParcelle", entity.NoParcelle);
                if (entity.NomParcelle == null)
                    command.Parameters.AddWithValue("@NomParcelle", entity.NomParcelle);
                if (entity.Surface == null)
                    command.Parameters.AddWithValue("@Surface", entity.Surface);
                if (entity.Coordonnees == null)
                    command.Parameters.AddWithValue("@Noordonnees", entity.Coordonnees);
                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new RepositoryException($"Erreur lors de la mise à jour partiel de la parcelle.", nameof(ParcelleRepository), "UpdatePartial", exception);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
