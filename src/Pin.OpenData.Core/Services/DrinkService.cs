
using Pin.OpenData.Core.Entities;
using Pin.OpenData.Core.Repositories.Interfaces;
using Pin.OpenData.Core.Services.Interfaces;
using System.Reflection;

namespace Pin.OpenData.Core.Services
{
    public class DrinkService : IDrinkService<Drink>
    {
        private readonly IBaseRepository<Drink> _drinkRepository;

        public DrinkService(IBaseRepository<Drink> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public Task CreateAsync(Drink entity)
        {
            var drinks = _drinkRepository.GetAllAsync().Result;

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Ingredients == null)
                throw new ArgumentNullException(nameof(entity.Ingredients));

            if (drinks.Any(d => d.Name.ToUpper().Equals(entity.Name.ToUpper())))
                 throw new ArgumentException("Drink with this name already exists");

            _drinkRepository.CreateAsync(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            if (_drinkRepository.GetByIdAsync(id).Result == null)
                throw new ArgumentException("Drink with this id does not exist");

            _drinkRepository.DeleteAsync(id);
            return Task.CompletedTask;
        }

        public Task<IQueryable<Drink>> GetAllAsync()
        {
            return _drinkRepository.GetAllAsync();
        }

        public Task<Drink> GetByIdAsync(int id)
        {
            var drink = _drinkRepository.GetByIdAsync(id).Result;
            if (drink == null)
                throw new ArgumentException("Drink with this id does not exist");
            return Task.FromResult(drink);
        }

        public Task UpdateAsync(Drink entity)
        {
            var drink = _drinkRepository.GetByIdAsync(entity.Id).Result;
            var drinks = _drinkRepository.GetAllAsync().Result;

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Ingredients == null)
                throw new ArgumentNullException(nameof(entity.Ingredients));


            if (drink.Name.ToUpper() != entity.Name.ToUpper())
            {
                if (drinks.Any(d => d.Name.ToUpper().Equals(entity.Name.ToUpper())))
                    throw new ArgumentException("Drink with this name already exists");
            }

            return _drinkRepository.UpdateAsync(entity);
        }
    }
}
