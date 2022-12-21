using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    public int CuisineId { get; set; }
    public int RestaurantId { get; set; }
    public string Pizza { get; set; }
    public string Pasta { get; set; }
    public string Sushi { get; set; }
    public Restaurant Restaurant { get; set; }

  }
}