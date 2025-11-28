using lr4_3.Models;

namespace lr4_3.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetByIdAsync(string id);
        Task CreateAsync(Restaurant restaurant);
        Task<bool> UpdateAsync(Restaurant restaurant);
        Task<bool> DeleteAsync(string id);
    }
}