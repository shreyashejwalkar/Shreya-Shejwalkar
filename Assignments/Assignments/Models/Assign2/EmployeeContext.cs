using System.Data.Entity;

namespace Assignments.Models.Assign2
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}