using Newtonsoft.Json;
using Pin.OpenData.Core.Entities;
using Pin.OpenData.Core.Repositories.Interfaces;

namespace Pin.OpenData.Core.Repositories
{
    public class DrinkRepository : IBaseRepository<Drink>
    {
        private readonly List<Drink> _drinks;

        public DrinkRepository()
        {
            Uri uri = new Uri("Data/cocktails.json", UriKind.Relative);
            using (StreamReader file = File.OpenText(uri.ToString()))
            {
                _drinks = JsonConvert.DeserializeObject<List<Drink>>(file.ReadToEnd());
            }
           
        }

        public Task CreateAsync(Drink entity)
        {
            entity.Id = _drinks.Max(x => x.Id) + 1;
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
