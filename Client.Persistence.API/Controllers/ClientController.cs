using Client.Persistence.Application.Client.DTO;
using Client.Persistence.Application.Client.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Gets all the clients
        /// </summary>
        /// <returns>All Clients</returns>
        [HttpGet]
        [Authorize(Roles = "Menager, Admin, Regular")]
        [ProducesResponseType(typeof(IEnumerable<ClientDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var clients = await _applicationService.GetAllAsync();

            return clients is List<ClientDTO> ? Ok(clients.ToList()) : BadRequest();
        }

        /// <summary>
        /// Gets a specified client
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <returns>A client</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Menager, Admin")]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _applicationService.GetAsync(id);

            return client is ClientDTO ? Ok(client) : BadRequest();
        }

        /// <summary>
        /// Gets a client with there public areas
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A client with there specific public areas</returns>
        [HttpGet("publicArea/{id}")]
        [Authorize(Roles = "Menager, Admin")]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithPublicArea(int id)
        {
            var client = await _applicationService.GetWithPublicAreaAsync(id);

            return client is ClientDTO ? Ok(client) : BadRequest();
        }

        /// <summary>
        /// Creates a new register from a client
        /// </summary>
        /// <param name="clientDTO"></param>
        /// <returns>If succeess or not</returns>
        [HttpPost]
        [Authorize(Roles = "Menager")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ClientDTO clientDTO)
        {
            if (clientDTO is ClientDTO)
            {
                await _applicationService.CreateAsync(clientDTO);
                return Created();
            }

            return BadRequest();
        }

        /// <summary>
        /// Update a client informations according to there identifier
        /// </summary>
        /// <param name="clientDTO"></param>
        /// <returns>If success or not</returns>
        [HttpPut]
        [Authorize(Roles = "Menager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(ClientDTO clientDTO)
        {
            if (clientDTO is ClientDTO)
            {
                await _applicationService.UpdateAsync(clientDTO);
                return NoContent();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete a client according to there identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If success or not</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Menager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _applicationService.DeleteAsync(id);
                return NoContent();
            }

            return BadRequest();
        }
    }
}
