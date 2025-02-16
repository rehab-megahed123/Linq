using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DAL.Configurations;
using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EntityFramework.DAL.Data_Base
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EntityFrameWork2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(m => m.Salary).IsRequired();
            new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
            modelBuilder.Entity<Department>().ToTable("Department", schema: "Rehab");
            modelBuilder.HasDefaultSchema("Rehab");
            //modelBuilder.Entity<Project>().ToView("Project");
            modelBuilder.Entity<Employee>().Ignore(e => e.Gender);
            modelBuilder.Entity<Project>().Property(p => p.Name).HasColumnName("Project_Name");
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasColumnType("nvarchar(30)");
            modelBuilder.Entity<Employee>().Property(b => b.Gender).HasMaxLength(30);
            modelBuilder.Entity<Department>().Property(d => d.Name).HasComment("This is Department Name");
            modelBuilder.Entity<Computer>().HasKey(a => a.Number).HasName("pK_ComputerNumber");
            //modelBuilder.Entity<Computer>().HasKey(s => new { s.Number,s.Name});
            modelBuilder.Entity<Project>().Property(a => a.Rate).HasDefaultValue(2);
            modelBuilder.Entity<Employee>().HasOne(a => a.Computer).WithOne(a => a.Employee).HasForeignKey<Computer>(d => d.EmployeeForeignKey);
           // modelBuilder.Entity<Department>().HasMany(b => b.Employees).WithOne();
            modelBuilder.Entity<Employee>().HasOne(b => b.Department).WithMany();
            modelBuilder.Entity<EmployeeProject>().HasKey(x => new { x.ProjectId, x.EmployeeId });
            modelBuilder.Entity<EmployeeProject>().HasOne(a => a.Employee).WithMany(a=>a.EmployeeProject);
            modelBuilder.Entity<EmployeeProject>().HasOne(a => a.Project).WithMany(c => c.EmployeeProject);
            modelBuilder.Entity<Employee>().Property(a => a.Salary).HasDefaultValue(2);
            modelBuilder.Entity<Computer>().Property(a => a.Description).HasComputedColumnSql("[Number]+' '+[Name]");

            

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Computer> Computers { get; set; }

    }
}
