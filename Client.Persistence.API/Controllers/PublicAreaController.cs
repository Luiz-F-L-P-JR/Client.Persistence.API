using Client.Persistence.Application.PublicArea.DTO;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Client.Persistence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicAreaController : ControllerBase
    {
        private readonly IPublicAreaApplicationService? _publicAreaApplicationService;

        public PublicAreaController(IPublicAreaApplicationService? publicAreaApplicationService)
        {
            _publicAreaApplicationService = publicAreaApplicationService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicAreaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PublicAreaDTO>>> Get()
        {
            return Ok();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PublicAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PublicAreaDTO>> Get(int id)
        {
            return Ok();
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(PublicAreaDTO publicAreaDTO)
        {
            return NoContent();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PublicAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(PublicAreaDTO publicAreaDTO)
        {
            return NoContent();
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
