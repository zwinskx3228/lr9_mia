using lr4_3.Models;

namespace lr4_3.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetAsync();
        Task<Order?> GetAsync(string id);
        Task UpdateAsync(Order order);
        Task DeleteAsync(string id);
    }
}