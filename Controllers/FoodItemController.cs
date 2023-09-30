using ERestaurant.DataConnection;
using ERestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ERestaurant.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly RestaurantDbContext _dbContext;

        public FoodItemController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var foodItems = _dbContext.FoodItemsTable.ToList();
            return View(foodItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _dbContext.FoodItemsTable.Add(foodItem);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodItem);
        }

        public IActionResult Edit(int id)
        {
            var foodItem = _dbContext.FoodItemsTable.Find(id);
            return View(foodItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(foodItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodItem);
        }

        public IActionResult Delete(int id)
        {
            var foodItem = _dbContext.FoodItemsTable.Find(id);
            return View(foodItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var foodItem = _dbContext.FoodItemsTable.Find(id);
            _dbContext.FoodItemsTable.Remove(foodItem);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
