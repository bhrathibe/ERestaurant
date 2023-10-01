using ERestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace ERestaurant.DataConnection
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItemsTable { get; set; }

        public DbSet<MenuItemImageRepository> FoodImageTable { get; set; }



        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  {
        //      optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
        //  }

    }

}
