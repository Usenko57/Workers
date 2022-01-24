using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Workers.DAL.Data;

namespace Workers.DAL.Contexts
{
    public class CompanyContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasKey(x => new { x.Surname, x.Name, x.Patronymic })
                .HasName("Id");
        }
    }
}
