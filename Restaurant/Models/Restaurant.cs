using System;
using System.Collections.Generic;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string LangBaan { get; set; }
    public string StLaan { get; set; }
    public string Timlarson { get; set; }
    public List<Cuisine> Cuisine { get; set; }
  }
}