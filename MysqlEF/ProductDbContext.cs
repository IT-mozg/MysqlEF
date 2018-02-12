using Microsoft.EntityFrameworkCore;

namespace MysqlEF
{
    public class ProductDbContext : DbContext
    {
        //public ProductDbContext()
        //{
        //    Database.EnsureCreated();
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=1111;database=mysqldb;");
        }
    }
}
