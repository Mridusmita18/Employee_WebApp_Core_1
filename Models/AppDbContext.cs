using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_WebApp_Core.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DeptId = 1,Name="HR" }) ;

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmpId = 1, Name="John Wick",Email="JohnWick@gmail.com",DeptId=1 }) ;
        }
        public DbSet<Employee> employees { get; set; }
    }
}
