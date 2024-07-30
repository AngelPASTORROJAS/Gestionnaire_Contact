using Gestionnaire_Contact.Models;
using Gestionnaire_Contact.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger; //
        private readonly ContactRepository _repository; //

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
            _repository = new ContactRepository();
        }


    }
}
