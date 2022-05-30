using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1D5O28T;database=CoreBlogApiDb;" +
                "integrated security = true");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
