using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Breakfast()
        { 
            return View();
        }

        public IActionResult Lunch()
        {
            return View();
        }


        public IActionResult Dinner()
        {
            return View();
        }
         

    }
}
