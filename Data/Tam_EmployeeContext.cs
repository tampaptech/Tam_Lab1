using Microsoft.EntityFrameworkCore;
using Tam_Lab1.Models;

namespace Tam_Lab1.Data
{
    public class Tam_EmployeeContext:DbContext
    {
        public Tam_EmployeeContext(DbContextOptions<Tam_EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Tam_Employee> Tam_Employee { get; set; }
    }
}
