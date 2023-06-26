using Microsoft.AspNetCore.Mvc;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;

namespace NetworkOfAirports_EF.API.Controllers
{
    [Route("efcore/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }
        private readonly IAirportService airportService;

        /// <summary>
        /// Get list of Airports
        /// </summary>
        /// <param name="parameters">Parameters for pagination and sorting of the collection</param>
        /// <returns>Returns list of Airports</returns>
        [HttpGet]
        public async Task<ActionResult> GetAllAirportAsync([FromQuery] AirportParameters parameters)
        {
            try
            {
                var list = await airportService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Airport by id
        /// </summary>
        /// <param name="id">Airport id</param>
        /// <returns>Returns entity by id</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AirportDTO>> GetAirportByIdAsync(Guid id)
        {
            try
            {
                var entity = await airportService.GetAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(entity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Craete new Airport
        /// </summary>
        /// <param name="newEntity">Data to create</param>
        /// <returns>Returns id created entity</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> AddAirportAsync(AirportCreateDTO newEntity)
        {
            try
            {
                var id = await airportService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update Airport by id
        /// </summary>
        /// <param name="updateEntity">Data to update</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAirportAsync(AirportUpdateDTO updateEntity)
        {
            try
            {
                await airportService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete Airport by id
        /// </summary>
        /// <param name="id">Airport Id</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAirportAsync(Guid id)
        {
            try
            {
                await airportService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
