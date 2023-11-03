using KaficiProjekat.Application.UseCases.Commands;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.Application.UseCases.DTO.Searches;
using KaficiProjekat.Application.UseCases.Queries;
using KaficiProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KaficiProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ReservationController(UseCaseHandler useCaseHandler) => _handler = useCaseHandler;




        // GET: api/<ReservationController>


        /// <summary>
        /// Get Reservations. Only authorized can search.
        /// </summary>
        /// <response code="200">Successful query.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] ReservationSearch search, [FromServices] IGetReservationsQuery query)
        {
            return Ok(_handler.HandleQuery(query,search));
        }

        // GET api/<ReservationController>/5

        /// <summary>
        /// Get single Reservaiton. Only authorized can search.
        /// </summary>
        /// <response code="200">Successful query.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>

        /// <summary>
        /// Create a new reservation.
        /// </summary>
        /// <response code="201">Successful command.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationDTO dto, [FromServices] ICreateReservationCommand command)
        {
            _handler.HandleCommand(command,dto);
            return StatusCode(201);
        }

        // PUT api/<ReservationController>/5

        /// <summary>
        /// Update a reservation.
        /// </summary>
        /// <response code="200">Successful query.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] UpdateReservationDTO dto, [FromServices] IUpdateReservationCommand command)
        {
            _handler.HandleCommand(command,dto);
            return Ok();

        }

        // DELETE api/<ReservationController>/5

        /// <summary>
        /// Delete a reservation.
        /// </summary>
        /// <response code="204">Successful query.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReservationCommand command)
        {
            _handler.HandleCommand(command,id);

            return NoContent();
        }
    }
}
