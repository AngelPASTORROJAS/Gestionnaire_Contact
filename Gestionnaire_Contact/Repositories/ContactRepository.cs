using Gestionnaire_Contact.Data;
using Gestionnaire_Contact.Models;

namespace Gestionnaire_Contact.Repositories
{
    public class ContactRepository : IRepository<ContactModel, string>
    {
        private GestionDbContext _context;
        public ContactRepository(GestionDbContext context)
        {
            _context = context;
        }
        public void Add(ContactModel model)
        {
            _context.Contact.Add(model);
            _context.SaveChanges();
        }
        public void Update(ContactModel model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        public void Delete(string fullname) 
        {
             ContactModel entity = _context.Contact.Find(fullname);
             _context.Contact.Remove(entity);
             _context.SaveChanges();
        }
        public IEnumerable<ContactModel> GetAll() 
        {
            return _context.Contact;
        }
        public ContactModel GetById(string fullname) 
        { 
            return _context.Contact.Find(fullname);
        }
    }
}
