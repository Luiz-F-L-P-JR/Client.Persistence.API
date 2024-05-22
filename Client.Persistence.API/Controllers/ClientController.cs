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
        [ProducesResponseType(typeof(IEnumerable<ClientDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            return Ok();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            return Ok();
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(ClientDTO clientDTO)
        {
            return NoContent();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(ClientDTO clientDTO)
        {
            return Ok();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
