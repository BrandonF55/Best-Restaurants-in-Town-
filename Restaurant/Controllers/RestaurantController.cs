using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class BestRestaurant : Controller
  {
    private readonly BestRestaurantContext _db;

    public BestRestaurantController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      
      return View();
    }
  }
}