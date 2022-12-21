using Microsoft.EntityFrameworkCore;

namespace BestRestaurant.Models
{
  public class BestRestaurantContext : DbContext
  {
    public DbSet<Cuisine> Cuisine { get; set; }

    public BestRestaurantContext(DbContextOptions options) : base(options) { }
  }
}