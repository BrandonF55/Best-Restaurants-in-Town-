using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;

    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index() //Index to cuisine view
    {
      List<Cuisine> model = _db.Cuisines //creates list of cuisines thats equal to the database results of Cuisines
                           .Include(cuisine => cuisine.Restaurant)  //includes
                           .ToList();
      return View(model);
    }

    public ActionResult Create()  //?
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }

    public ActionResult Create(Cuisine cuisine)
    {
      if (cuisine.RestaurantId == 0) //checks if restaurantId for the cuisine element is 0
      {
        return RedirectToAction("Create");  //Redirects to Create View if the restaurantId is 0
      }
      _db.Cuisines.Add(cuisine);   //Adds cuisine to cuisine table within _db 
      _db.SaveChanges();  //saves changes to database
      return RedirectToAction("Index"); //redirects to Index
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines
                          .Include(cuisine => cuisine.Restaurant)
                          .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisCuisine);
    }

    [HttpPost]  //posting our cuisine edit the database
    public ActionResult Edit(Cuisine cuisine) //takes in cuisine object
    {
      _db.Cuisines.Update(cuisine); //calles Cuisines table to Update the cuisine instance
      _db.SaveChanges();  //saves changes of the updated cuisine instance above
      return RedirectToAction("Index"); //redirects to Index of Cuisine View
    }

    public ActionResult Delete(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.RestaurantId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.RestaurantId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}