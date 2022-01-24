using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Workers.Shared.Data.Models;

namespace Workers.Shared.Data.Contexts
{
    public class CompanyContext : DbContext
    {
        public DbSet<Worker> WorkersInCompany { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasAlternateKey(x => new { x.Surname, x.Name, x.Patronymic });
        }
    }
}
