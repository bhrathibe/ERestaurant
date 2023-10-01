using System.ComponentModel.DataAnnotations;

namespace ERestaurant.Models
{
    public class MenuItemImageRepository
    {
        [Key]
        public int Image_ID { get; set; }

        [Required]
        public byte[] Image_Data { get; set; }

        public string Image_Desc { get; set; }
    }

}

