using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebApp_Core.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }

        public int DeptId { get; set; }
        public Department department { get; set; }
    }
}
