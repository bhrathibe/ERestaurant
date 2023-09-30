using System.ComponentModel.DataAnnotations;

namespace ERestaurant.Models
{
    public class FoodItem
    {
        [Key] // This indicates that Food_Id is the primary key
        public int Food_Id { get; set; }

        [Required(ErrorMessage = "Food Name is required")]
        [Display(Name = "Food Name")]
        public string Food_Name { get; set; }

        [Required(ErrorMessage = "Food Description is required")]
        [Display(Name = "Food Description")]
        public string Food_Description { get; set; }

        [Required(ErrorMessage = "Food Price is required")]
        [Display(Name = "Food Price")]
        public int Food_Price { get; set; }
    }
}
