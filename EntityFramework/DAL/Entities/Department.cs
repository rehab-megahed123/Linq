using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DAL.Entities
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }

        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
