using System;
using System.Collections.Generic;
using System.Text;
using Workers.Shared.Data.Models;

namespace Workers.Shared.Data.Interfaces
{
    public interface IWorkersInCompanyRepository
    {
        int Add(Worker item);

        Worker Get(int id);

        void Update(Worker item, int id);

        void Delete(int id);
    }
}
