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
            var clients = await _applicationService.GetAllAsync();

            return clients is List<ClientDTO> ? Ok(clients.ToList()) : NotFound();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            var client = await _applicationService.GetAsync(id);

            return client is ClientDTO ? Ok(client) : NotFound();
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(ClientDTO clientDTO)
        {
            if (clientDTO is ClientDTO)
            {
                await _applicationService.CreateAsync(clientDTO);
                return NoContent();
            }

            return NotFound();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(ClientDTO clientDTO)
        {
            if (clientDTO is ClientDTO)
            {
                await _applicationService.UpdateAsync(clientDTO);
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _applicationService.DeleteAsync(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}
