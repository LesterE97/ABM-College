using employeeData;
using System.Data.Entity;

namespace EmployeeData
{
    public class TestEntities : DbContext
    {
        public TestEntities() : base("name=TestEntities")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
