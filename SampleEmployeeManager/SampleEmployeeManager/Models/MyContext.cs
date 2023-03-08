using System.Data.Entity;

namespace XSManager.Models
{
    public class MyContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
    }
}