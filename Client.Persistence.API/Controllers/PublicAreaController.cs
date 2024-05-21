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
        public async Task<ActionResult<IEnumerable<PublicAreaDTO>>> Get()
        {
            return Ok();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicAreaDTO>> Get(int id)
        {
            return Ok();
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            return NoContent();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(PublicAreaDTO publicAreaDTO)
        {
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
