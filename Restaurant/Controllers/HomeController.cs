using Microsoft.AspNetCore.Mvc;

namespace BestRestaurant.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public IActionResult Index()
    {
      return View();
    }
  }
}