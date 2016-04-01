using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TCIApplication.Models;


namespace TCIApplication.DAL
{
    public class TCIApplicationContext : DbContext
    {

        public TCIApplicationContext() : base("TCIApplicationContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}