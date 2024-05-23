using Microsoft.EntityFrameworkCore;
using Laptopshopping.Models;

namespace Laptopshopping.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Orderdetails> OrderDetails { get; set; }
        public DbSet<Cartitems> Cartitems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=laptopshop;");
        }
        

    }
}
