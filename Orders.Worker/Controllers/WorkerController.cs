using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Worker.Application;

namespace Orders.Worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("{message}")]
        public async Task<string> Get(string message)
        {
            return await _workerService.GetMessage(message);
        }
    }
}
