using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebApp_Core.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Add(Employee employeee);
        Task<Employee> Delete(int id);
        Task<Employee> Update(Employee emploChanges);
        Employee GetEmployeeByIdAndName(int id)
        {
            return new Employee { Name = "rahul" };
        }

    }
}
