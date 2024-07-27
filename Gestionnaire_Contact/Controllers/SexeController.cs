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
        private readonly SexeRepository _repository;

        public SexeController(ILogger<SexeController> logger)
        {
            _logger = logger;
            _repository = new SexeRepository();
        }

        [HttpGet(Name = "GetSexe")]
        public IEnumerable<SexeModel> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SexeModel> Get(string id)
        {
            var model = _repository.GetById(id);
            return model.Sexe == null? NotFound() : model;
        }

        [HttpPost]
        public void Post([FromBody] SexeModel value)
        {
            _repository.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SexeModel value)
        {
            _repository.Update(value, id);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
