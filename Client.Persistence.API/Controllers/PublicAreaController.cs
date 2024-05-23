using Client.Persistence.Application.PublicArea.DTO;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Client.Persistence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicAreaController : ControllerBase
    {
        private readonly IPublicAreaApplicationService? _applicationService;

        public PublicAreaController(IPublicAreaApplicationService? applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicAreaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PublicAreaDTO>>> Get()
        {
            var publicAreas = await _applicationService.GetAllAsync();

            return publicAreas is List<PublicAreaDTO> ? Ok(publicAreas.ToList()) : NotFound();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PublicAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PublicAreaDTO>> GetbyId(int id)
        {
            var publicArea = await _applicationService.GetAsync(id);

            return publicArea is PublicAreaDTO ? Ok(publicArea) : NotFound();
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(PublicAreaDTO publicAreaDTO)
        {
            if(publicAreaDTO is PublicAreaDTO)
            {
                await _applicationService.CreateAsync(publicAreaDTO);
                return NoContent();
            }

            return NotFound();
        }

        // PUT api/<ClientController>/5
        [HttpPut()]
        [ProducesResponseType(typeof(PublicAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(PublicAreaDTO publicAreaDTO)
        {
            if (publicAreaDTO is PublicAreaDTO)
            {
                await _applicationService.UpdateAsync(publicAreaDTO);
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
