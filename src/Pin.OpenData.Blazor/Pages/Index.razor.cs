using Microsoft.AspNetCore.Components;
using Pin.OpenData.Core.Entities;
using Pin.OpenData.Core.Services.Interfaces;

namespace Pin.OpenData.Blazor.Pages
{
    public partial class Index
    {
        [Inject]
        private IDrinkService<Drink> DrinkService { get; init; }

        private Drink[] allDrinks;
        private Drink currentDrink = null;
        private Drink drinkToDelete = null;
        private Statistic statistics;
        private string error;

        private bool showDetails;
        private bool confirmDeletion;

        protected override async Task OnInitializedAsync()
        {
            await RefreshDrinks();
        }

        private async Task RefreshDrinks()
        {
            allDrinks = (await DrinkService.GetAllAsync()).ToArray();
            statistics = await DrinkService.GetShortStatistics();
            currentDrink = null;
            showDetails = false;
        }

        private void AddDrink()
        {
            currentDrink = new Drink();
        }

        private async void DeleteDrink()
        {
            try
            {
                await DrinkService.DeleteAsync(drinkToDelete.Id);
                await RefreshDrinks();
                confirmDeletion = false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private async Task EditDrink(Drink drink)
        {
            currentDrink = await DrinkService.GetByIdAsync(drink.Id);
        }

        private async void SaveDrink(Drink drink)
        {
            try
            {
                if (drink.Id == 0)
                    await DrinkService.CreateAsync(drink);
                else
                    await DrinkService.UpdateAsync(drink);
                await RefreshDrinks();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                error = ex.Message;
            }
        }

        private async Task DetailsDrink(Drink drink)
        {
            currentDrink = await DrinkService.GetByIdAsync(drink.Id);
            showDetails = true;
        }

        private async Task ReturnToDrinks()
        {
            await RefreshDrinks();
        }

        private void DeleteConfirmation(Drink drink)
        {
            drinkToDelete = drink;
            confirmDeletion = true;
        }

        private void Cancel()
        {
            currentDrink = null;
            drinkToDelete = null;
            confirmDeletion = false;
        }
    }
}
