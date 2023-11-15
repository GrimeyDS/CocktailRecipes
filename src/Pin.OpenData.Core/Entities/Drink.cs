
namespace Pin.OpenData.Core.Entities
{
    public class Drink : BaseEntity
    {
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAlcoholic { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
