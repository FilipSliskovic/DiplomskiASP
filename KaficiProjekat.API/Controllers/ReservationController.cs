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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
