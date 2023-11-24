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
    [ApiController]
    [Authorize]
    public class WorkerController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public WorkerController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }


        // GET: api/<WorkerController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetCafeWorkersQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query,search));
        }

    }
}
