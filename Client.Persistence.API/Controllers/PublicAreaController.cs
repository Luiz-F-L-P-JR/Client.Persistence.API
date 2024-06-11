using Client.Persistence.Application.PublicArea.DTO;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Gets all the public areas
        /// </summary>
        /// <returns>All public areas</returns>
        [HttpGet]
        [Authorize(Roles = "Menager,Admin,Regular")]
        [ProducesResponseType(typeof(IEnumerable<PublicAreaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var publicAreas = await _applicationService.GetAllAsync();

            return publicAreas is List<PublicAreaDTO> ? Ok(publicAreas.ToList()) : BadRequest();
        }

        /// <summary>
        /// Gets a specified public area
        /// </summary>
        /// <param name="id">public area identifier</param>
        /// <returns>A public area</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Menager,Admin")]
        [ProducesResponseType(typeof(PublicAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetbyId(int id)
        {
            var publicArea = await _applicationService.GetAsync(id);

            return publicArea is PublicAreaDTO ? Ok(publicArea) : BadRequest();
        }

        /// <summary>
        /// Creates a new register of a public area
        /// </summary>
        /// <param name="publicAreaDTO"></param>
        /// <returns>If succeess or not</returns>
        [HttpPost]
        [Authorize(Roles = "Menager")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(PublicAreaDTO publicAreaDTO)
        {
            if(publicAreaDTO is PublicAreaDTO)
            {
                await _applicationService.CreateAsync(publicAreaDTO);
                return Created();
            }

            return BadRequest();
        }

        /// <summary>
        /// Update a public area informations according to identifier
        /// </summary>
        /// <param name="publicAreaDTO"></param>
        /// <returns>If success or not</returns>
        [HttpPut()]
        [Authorize(Roles = "Menager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(PublicAreaDTO publicAreaDTO)
        {
            if (publicAreaDTO is PublicAreaDTO)
            {
                await _applicationService.UpdateAsync(publicAreaDTO);
                return NoContent();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete a public area according to identifier
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
