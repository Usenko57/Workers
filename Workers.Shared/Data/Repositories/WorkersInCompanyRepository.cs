using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workers.Shared.Data.Contexts;
using Workers.Shared.Data.Interfaces;
using Workers.Shared.Data.Models;

namespace Workers.Shared.Data.Repositories
{
    public class WorkersInCompanyRepository : IWorkersInCompanyRepository
    {
        private readonly CompanyContext _companyContext;

        public WorkersInCompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public int Add(Worker worker)
        {
            var ifExistsWithTheSameData = IfExists(worker);

            if (ifExistsWithTheSameData)
            {
                return 0;
            }

            else
            {
                _companyContext.Add(worker);
                _companyContext.SaveChanges();

                return 1;
            }
        }

        public void Delete(int id)
        {
            var worker = _companyContext.WorkersInCompany
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();

            if(worker != null)
            {
                _companyContext.Remove(worker);
                _companyContext.SaveChanges();
            }
        }

        public Worker Get(int id)
        {
            var worker = _companyContext.WorkersInCompany
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();

            return worker;
        }

        public void Update(Worker item, int id)
        {
            var worker = _companyContext.WorkersInCompany
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();

            if(worker != null)
            {
                worker.Name = item.Name;
                worker.Surname = item.Surname;
                worker.Patronymic = item.Patronymic;
                worker.Position = item.Position;
            }
        }

        private bool IfExists(Worker worker)
        {
            var existingWorker = _companyContext.WorkersInCompany
                                         .Where(x => x.Surname == worker.Surname &&
                                         x.Name == worker.Name && x.Patronymic == worker.Patronymic)
                                         .FirstOrDefault();

            if(existingWorker != null)
            {
                return true;
            }

            return false;
        }
    }
}
