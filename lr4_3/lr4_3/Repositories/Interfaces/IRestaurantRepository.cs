using lr4_3.Models;

namespace lr4_3.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task CreateAsync(Restaurant restaurant);
        Task<List<Restaurant>> GetAsync();
        Task<Restaurant?> GetAsync(string id);
        Task UpdateAsync(Restaurant restaurant);
        Task DeleteAsync(string id);
    }
}