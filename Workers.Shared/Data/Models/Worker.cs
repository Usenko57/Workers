using System;
using System.Collections.Generic;
using System.Text;

namespace Workers.Shared.Data.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Position { get; set; }
    }
}
