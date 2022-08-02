using Microsoft.EntityFrameworkCore;
using PracticaProiect.Entities;

namespace PracticaProiect.Contexts
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
          : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }
    }
}
