using Microsoft.AspNetCore.Components;
using Pin.OpenData.Core.Entities;

namespace Pin.OpenData.Blazor.Components
{
    public abstract class DrinksComponentBase : ComponentBase
    {
        [Parameter]
        public Drink[] Drinks { get; set; }

        [Parameter]
        public Drink Drink { get; set; }

        [Parameter]
        public Ingredient Ingredient { get; set; }
    }
}
