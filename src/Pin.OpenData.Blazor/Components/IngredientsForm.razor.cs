using Pin.OpenData.Core.Entities;

namespace Pin.OpenData.Blazor.Components
{
    public partial class IngredientsForm
    {
        protected override void OnInitialized()
        {
            if (Drink.Ingredients == null)
            {
                Drink.Ingredients = new List<Ingredient>();
            };

            var ingredientCount = Drink.Ingredients.Count;

            if (ingredientCount <= 5)
            {
                for (int i = 0; i < 10 - ingredientCount; i++)
                {
                    Drink.Ingredients.Add(new Ingredient());
                };
            };

        }
    }
}
