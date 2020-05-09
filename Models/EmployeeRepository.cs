using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebApp_Core.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private AppDbContext dbContext;
        public async Task<Employee> Add(Employee employee)
        {
            await dbContext.employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            var emp =await dbContext.employees.FindAsync(employee.EmpId);
            return emp;
        }

        public async Task<Employee> Delete(int id)
        {
            var emp = await dbContext.employees.FindAsync(id);
                if (emp != null)
            {
                dbContext.employees.Remove(emp);
                await dbContext.SaveChangesAsync();
            }
            return emp;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await dbContext.employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var emp= await dbContext.employees.FindAsync(id);
            return  emp;

        }

        public async Task<Employee> Update(Employee employeeChanges)
        {
           var emp= dbContext.employees.Attach(employeeChanges);
            emp.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return employeeChanges;
        }
    }
}
