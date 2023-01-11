using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApiFastTactsoft.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable
        {
            get; set;
        }
    }
}
