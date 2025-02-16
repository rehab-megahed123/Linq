using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DAL.Entities
{
    [Table("Employee",Schema ="Rehab")]
    public class Employee
    {
        public Employee( string name, decimal salary)
        {
            
            Name = name;
            Salary = salary;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        [Column("Employee_Salary")]
        public decimal Salary { get; set; }
        
        public string Gender { get; set; }
        public Car Car { get; set; }
        public Computer Computer { get; set; }
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public List<EmployeeProject> EmployeeProject { get; set; }


    }
}
