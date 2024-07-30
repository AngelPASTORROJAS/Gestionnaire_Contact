using Gestionnaire_Contact.Data;
using Gestionnaire_Contact.Models;
using Gestionnaire_Contact.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Contact.Controllers
{
    [Route("[controller]")] //API vide
    [ApiController]
    public class SexeController : ControllerBase
    {
        private readonly ILogger<SexeController> _logger;
        private readonly GestionDbContext _context;

        public SexeController(ILogger<SexeController> logger, GestionDbContext context)
        {
            _logger = logger;
            _context = context;
        }

    }
}
