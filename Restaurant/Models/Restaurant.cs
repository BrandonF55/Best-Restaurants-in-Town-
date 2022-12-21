using System;
using System.Collections.Generic;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public List<Cuisine> Cuisines { get; set; }
  }
}