using Pin.OpenData.Core.Entities;
using Pin.OpenData.Core.Repositories.Interfaces;
using System.Diagnostics;

namespace Pin.OpenData.Core.Repositories
{
    public class DrinkRepository : IBaseRepository<Drink>
    {
        private readonly List<Drink> _drinks;

        public DrinkRepository()
        {
            // add csv data
            _drinks = new List<Drink>();
        }

        public Task CreateAsync(Drink entity)
        {
            _drinks.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _drinks.Remove(_drinks.FirstOrDefault(x => x.Id == id));
            return Task.CompletedTask;
        }

        public Task<IQueryable<Drink>> GetAllAsync()
        {
            return Task.FromResult(_drinks.AsQueryable());
        }

        public Task<Drink> GetByIdAsync(int id)
        {
            var drink = _drinks.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(drink);
        }

        public Task UpdateAsync(Drink entity)
        {
            var drink = _drinks.FirstOrDefault(x => x.Id == entity.Id);
            drink = entity;
            return Task.CompletedTask;
        }
    }
}
