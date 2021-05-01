using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Employee>().HasData(new Employee { 
                EmpId=12345,
                Name="dinesh",
                FatherName="Suriyan",
                MotherName="jeyalakshmi",
                Address="madurai,tamilnadu",
                Salary=12345.54,
                role=Role.Trainee,
                Fresher=true
            });
        }
    }
}
