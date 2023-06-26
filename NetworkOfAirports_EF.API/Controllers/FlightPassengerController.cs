using Microsoft.AspNetCore.Mvc;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;

namespace NetworkOfAirports_EF.API.Controllers
{
    [Route("efcore/[controller]")]
    [ApiController]
    public class FlightPassengerController : ControllerBase
    {
        public FlightPassengerController(IFlightPassengerService flightPassengerService)
        {
            this.flightPassengerService = flightPassengerService;
        }
        private readonly IFlightPassengerService flightPassengerService;

        /// <summary>
        /// Get list of FlightPassengers
        /// </summary>
        /// <param name="parameters">Parameters for pagination and sorting of the collection</param>
        /// <returns>Returns list of FlightPassengers</returns>
        [HttpGet]
        public async Task<ActionResult> GetAllFlightPassengerAsync([FromQuery] FlightPassengerParameters parameters)
        {
            try
            {
                var list = await flightPassengerService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get FlightPassenger by ids
        /// </summary>
        /// <param name="FlightId">Flight id</param>
        /// <param name="PassengerId">Passenger id</param>
        /// <returns>Returns entity by ids</returns>
        [HttpGet("{FlightId:guid}/{PassengerId:guid}")]
        public async Task<ActionResult<FlightPassengerDTO>> GetFlightPassengerByIdAsync(Guid FlightId, Guid PassengerId)
        {
            try
            {
                var entity = await flightPassengerService.GetAsync(FlightId, PassengerId);
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
        /// Craete new FlightPassenger
        /// </summary>
        /// <param name="newEntity">Data to create</param>
        /// <returns>Returns id created entity</returns>
        [HttpPost]
        public async Task<ActionResult<(Guid, Guid)>> AddFlightPassengerAsync(FlightPassengerCreateDTO newEntity)
        {
            try
            {
                var id = await flightPassengerService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update FlightPassenger by id
        /// </summary>
        /// <param name="updateEntity">Data to update</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpPut]
        public async Task<ActionResult> UpdateFlightPassengerAsync(FlightPassengerUpdateDTO updateEntity)
        {
            try
            {
                await flightPassengerService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete FlightPassenger by ids
        /// </summary>
        /// <param name="FlightId">Flight id</param>
        /// <param name="PassengerId">Passenger id</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpDelete("{FlightId:guid}/{PassengerId:guid}")]
        public async Task<ActionResult> DeleteFlightPassengerAsync(Guid FlightId, Guid PassengerId)
        {
            try
            {
                await flightPassengerService.DeleteAsync(FlightId, PassengerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
