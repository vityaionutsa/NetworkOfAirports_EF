using Microsoft.AspNetCore.Mvc;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;

namespace NetworkOfAirports_EF.API.Controllers
{
    [Route("efcore/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        private readonly IFlightService flightService;

        /// <summary>
        /// Get list of Flights
        /// </summary>
        /// <param name="parameters">Parameters for pagination and sorting of the collection</param>
        /// <returns>Returns list of Flights</returns>
        [HttpGet]
        public async Task<ActionResult> GetAllFlightAsync([FromQuery] FlightParameters parameters)
        {
            try
            {
                var list = await flightService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Flight by id
        /// </summary>
        /// <param name="id">Flight id</param>
        /// <returns>Returns entity by id</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FlightDTO>> GetFlightByIdAsync(Guid id)
        {
            try
            {
                var entity = await flightService.GetAsync(id);
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
        /// Craete new Flight
        /// </summary>
        /// <param name="newEntity">Data to create</param>
        /// <returns>Returns id created entity</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> AddFlightAsync(FlightCreateDTO newEntity)
        {
            try
            {
                var id = await flightService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update Flight by id
        /// </summary>
        /// <param name="updateEntity">Data to update</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpPut]
        public async Task<ActionResult> UpdateFlightAsync(FlightUpdateDTO updateEntity)
        {
            try
            {
                await flightService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete Flight by id
        /// </summary>
        /// <param name="id">Flight Id</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteFlightAsync(Guid id)
        {
            try
            {
                await flightService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
