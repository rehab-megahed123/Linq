using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DAL.Entities
{
    public class Project
    {
        [Comment("This is The id Of Project")]
        public long Id { get; set; }
        [Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; }
        [NotMapped]
        public DateTime AddedOn { get; set; }
        public int Rate { get; set; }
        public List<EmployeeProject> EmployeeProject { get; set; }
    }
}
