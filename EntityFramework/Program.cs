using EntityFramework.DAL.Data_Base;
using EntityFramework.DAL.Entities;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();
            var employee1 = new Employee("Rehab Megahed",40_000);
            var employee2 = new Employee("Tasneem Mohammed",30_000);
            var employee3 = new Employee("Hanan Hammety",35_000);
            var employee4 = new Employee("Menna Sameh",33_000);
            var department1 = new Department("FullStack.net");
            _context.Employees.Add(employee1);
            _context.Employees.Add(employee2);
            _context.Employees.Add(employee3);
            _context.Employees.Add(employee4);
            _context.Departments.Add(department1);
            _context.SaveChanges();

        }
    }
}
