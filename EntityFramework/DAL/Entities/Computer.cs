using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DAL.Entities
{
    public class Computer
    {
        public long Number { get; set; }
        public string Description { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        //[ForeignKey(" EmployeeForeignKey")]
        public Employee Employee { get; set; }
        public long EmployeeForeignKey { get; set; }
    }
}
