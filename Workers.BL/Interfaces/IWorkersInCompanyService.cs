using System;
using System.Collections.Generic;
using System.Text;
using Workers.BL.Models;

namespace Workers.BL.Interfaces
{
    public interface IWorkersInCompanyService
    {
        int Add(WorkerDTO item);

        WorkerDTO Get(int id);

        void Update(WorkerDTO item, int id);

        void Delete(int id);
    }
}
