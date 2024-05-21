using Client.Persistence.Application.Client.DTO;
using Client.Persistence.Application.Client.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Client.Persistence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplicationService? _applicationService;

        public ClientController(IClientApplicationService? applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            return Ok();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            return Ok();
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> Post(ClientDTO clientDTO)
        {
            return NoContent();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<ActionResult> Put(ClientDTO clientDTO)
        {
            return Ok();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
