using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using lr4_3.Services.Interfaces;

namespace lr4_3.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            await _repository.CreateAsync(restaurant);
        }

        public async Task<bool> UpdateAsync(Restaurant restaurant)
        {
            var existing = await _repository.GetAsync(restaurant.Id);
            if (existing == null)
                return false;

            await _repository.UpdateAsync(restaurant);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _repository.GetAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}