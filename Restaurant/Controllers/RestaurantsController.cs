using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantsController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.ToList();  //creates a list of Restaurant items equal to the database restaurant table converted to a list
      return View(model);
    }

    public ActionResult Create()  //returns create view
    {
      return View();
    }

    [HttpPost]  //posts what was created above to the sql database
    public ActionResult Create(Restaurant restaurant)   //accepts a restaurant type
    {
      _db.Restaurants.Add(restaurant);  //adds restaurant object to database
      _db.SaveChanges(); //saves database changes
      return RedirectToAction("Index"); //redirects to Index method
    }

    public ActionResult Details(int id)  // ?
    {
      Restaurant thisRestaurant = _db.Restaurants
                                        .Include(restaurant => restaurant.Cuisines)
                                        .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);  //creates a restaurant object that's equal to the id of the first id of the inputted restaraurant
      return View(thisRestaurant);  //returns to edit view
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant) //takes in restaurant object
    {
      _db.Restaurants.Update(restaurant); //passes restaurant object to Restaurants database table
      _db.SaveChanges();  //saves the updated table to the database
      return RedirectToAction("Index"); //redirects to Index method
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant); //removes restaurant from database table
      _db.SaveChanges(); //saves database changes
      return RedirectToAction("Index");
    }






  }
}