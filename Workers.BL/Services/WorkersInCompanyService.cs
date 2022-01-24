using System;
using System.Collections.Generic;
using System.Text;
using Workers.BL.Interfaces;
using Workers.BL.Models;
using Workers.Shared.Data.Interfaces;
using Workers.Shared.Data.Models;

namespace Workers.BL.Services
{
    public class WorkersInCompanyService : IWorkersInCompanyService
    {
        private readonly IWorkersInCompanyRepository _workersInCompanyRepository;

        public WorkersInCompanyService(IWorkersInCompanyRepository workersInCompanyRepository)
        {
            _workersInCompanyRepository = workersInCompanyRepository;
        }

        public int Add(WorkerDTO item)
        {
            var worker = new Worker()
            {
                Name = item.Name,
                Patronymic = item.Patronymic,
                Position = item.Position,
                Surname = item.Surname
            };

            int result = _workersInCompanyRepository.Add(worker);

            return result;
        }

        public void Delete(int id)
        {
            _workersInCompanyRepository.Delete(id);
        }

        public WorkerDTO Get(int id)
        {
            var worker = _workersInCompanyRepository.Get(id);

            if (worker != null)
            {
                var workerDto = new WorkerDTO
                {
                    Name = worker.Name,
                    Patronymic = worker.Patronymic,
                    Position = worker.Position,
                    Surname = worker.Surname
                };

                return workerDto;
            }

            return null;
        }

        public void Update(WorkerDTO item, int id)
        {
            var worker = new Worker()
            {
                Name = item.Name,
                Patronymic = item.Patronymic,
                Position = item.Position,
                Surname = item.Surname
            };

            _workersInCompanyRepository.Update(worker, id);
        }
    }
}
