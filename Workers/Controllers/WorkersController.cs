using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workers.ViewModels;

namespace Workers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {
        public WorkersController(ILogger<WorkersController> logger)
        {
            //_logger = logger;
        }

        [HttpGet]
        public IActionResult  Get()
        {
            var model = new WorkerViewModel();

            return Ok(model);
        }
    }
}
