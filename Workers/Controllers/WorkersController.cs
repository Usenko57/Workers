using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workers.BL.Interfaces;
using Workers.BL.Models;
using Workers.ViewModels;

namespace Workers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersInCompanyService _workersInCompanyService;

        public WorkersController(IWorkersInCompanyService workersInCompanyService)
        {
            _workersInCompanyService = workersInCompanyService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult  Get(int id)
        {
            var worker = _workersInCompanyService.Get(id);

            if (worker != null)
            {
                var model = new WorkerViewModel
                {
                    Name = worker.Name,
                    Patronymic = worker.Patronymic,
                    Surname = worker.Surname,
                    Position = worker.Position
                };

                return Ok(model);
            }

            return NotFound();
        }

        [HttpPost]        
        public IActionResult Post(WorkerViewModel model)
        {
            var workerDto = new WorkerDTO
            {
                Name = model.Name,
                Position = model.Position,
                Surname = model.Surname,
                Patronymic = model.Patronymic
            };

            int result = _workersInCompanyService.Add(workerDto);

            if(result == 0)
            {
                throw new Exception("Пользователь с таким именем уже иммется");
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(WorkerViewModel model, int id)
        {
            var workerDto = new WorkerDTO
            {
                Name = model.Name,
                Position = model.Position,
                Surname = model.Surname,
                Patronymic = model.Patronymic
            };

            _workersInCompanyService.Update(workerDto, id);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _workersInCompanyService.Delete(id);

            return Ok();
        }
    }
}
