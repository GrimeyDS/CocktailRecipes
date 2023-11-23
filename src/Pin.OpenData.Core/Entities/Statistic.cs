
namespace Pin.OpenData.Core.Entities
{
    public class Statistic
    {
        public int DrinksCount { get; set; }
        public int Alcoholic { get; set; }
        public int NonAlcoholic { get; set; }
        public string MostPopularIngredient { get; set; }
        public string MostPopularCategory { get; set; }
        public int Shots { get; set; }
        public int Beer { get; set; }
        public int Cocktails { get; set; }
        public int OrdinaryDrink { get; set; }
        public int Other { get; set; }
    }
}
