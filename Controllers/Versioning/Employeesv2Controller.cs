using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_WebApp_Core.Models;

namespace Employee_WebApp_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class Employeesv2Controller : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public Employeesv2Controller(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
        {           
            var employees=await employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }
            try
            {
                await employeeRepository.Update(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (employeeRepository.GetEmployeeById(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await employeeRepository.Add(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await employeeRepository.Delete(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Employee>> Patch(int id, Employee employee)
        {            
            try
            {
                await employeeRepository.Update(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (employeeRepository.GetEmployeeById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
