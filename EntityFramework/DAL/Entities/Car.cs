using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DAL.Entities
{
    public class Car
    {
        [Key]
        public int  Number { get; set; }
        [MaxLength(30)]
        public string Color { get; set; }
        [MaxLength(30)]
        public string Owner { get; set; }
      
        public Employee Employee { get; set; }
        public long EmployeeId { get; set; }
    }
}
