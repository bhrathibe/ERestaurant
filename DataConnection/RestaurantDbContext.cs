using ERestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ERestaurant.DataConnection
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItemsTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
        }

    }

}
