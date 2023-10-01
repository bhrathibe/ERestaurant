using System;
using System.IO;
using System.Threading.Tasks;
using ERestaurant.DataConnection;
using ERestaurant.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.Controllers
{
    public class ImageUploader : Controller
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploader(RestaurantDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index() { 
            
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image, string description)
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    // Generate a unique filename
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                    // Combine the file path with the wwwroot path
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }

                    // Save image information to the database
                    var menuItemImage = new MenuItemImageRepository
                    {
                        Image_Data = System.IO.File.ReadAllBytes(filePath),
                        Image_Desc = description
                    };
                    _dbContext.FoodImageTable.Add(menuItemImage);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index", "ImageUploader");
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    return View("Error");
                }
            }

            return View("Error");
        }

        // Other actions...
    }
}
