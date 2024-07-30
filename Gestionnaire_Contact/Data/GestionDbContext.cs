using Gestionnaire_Contact.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestionnaire_Contact.Data
{
    public class GestionDbContext : DbContext
    {
        public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
        {
        }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<SexeModel> Sexe { get; set; }
    }
}