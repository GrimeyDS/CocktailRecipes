
using System.ComponentModel.DataAnnotations;

namespace Pin.OpenData.Core.Entities
{
    public class Drink : BaseEntity
    {
        [StringLength(50, ErrorMessage = "Please provide a glass not longer 50 characters.")]
        public string Glass { get; set; }
        [StringLength(1000, ErrorMessage = "Please provide an instruction not longer 1000 characters.")]
        public string Instructions { get; set; }
        [StringLength(50, ErrorMessage = "Please provide a category not longer 50 characters.")]
        [Required]
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAlcoholic { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
