using Microsoft.AspNetCore.Mvc;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;

namespace NetworkOfAirports_EF.API.Controllers
{
    [Route("efcore/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        public AirlineController(IAirlineService airlineService)
        {
            this.airlineService = airlineService;
        }
        private readonly IAirlineService airlineService;


        /// <summary>
        /// Get list of Airlines
        /// </summary>
        /// <param name="parameters">Parameters for pagination and sorting of the collection</param>
        /// <returns>Returns list of Airlines</returns>
        [HttpGet]
        public async Task<ActionResult> GetAllAirlineAsync([FromQuery] AirlineParameters parameters)
        {
            try
            {
                var list = await airlineService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Airline by id
        /// </summary>
        /// <param name="id">Airline id</param>
        /// <returns>Returns entity by id</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AirlineDTO>> GetAirlineByIdAsync(Guid id)
        {
            try
            {
                var entity = await airlineService.GetAsync(id);
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
        /// Craete new Airline
        /// </summary>
        /// <param name="newEntity">Data to create</param>
        /// <returns>Returns id created entity</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> AddAirlineAsync(AirlineCreateDTO newEntity)
        {
            try
            {
                var id = await airlineService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update Airline by id
        /// </summary>
        /// <param name="updateEntity">Data to update</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAirlineAsync(AirlineUpdateDTO updateEntity)
        {
            try
            {
                await airlineService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete Airline by id
        /// </summary>
        /// <param name="id">Airline Id</param>
        /// <returns>The created <see cref="OkResult"/> for the respons</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAirlineAsync(Guid id)
        {
            try
            {
                await airlineService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
