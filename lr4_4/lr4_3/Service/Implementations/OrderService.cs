using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using lr4_3.Services.Interfaces;

namespace lr4_3.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Order?> GetByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateAsync(Order order)
        {
            await _repository.CreateAsync(order);
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            var existing = await _repository.GetAsync(order.Id);
            if (existing == null)
                return false;

            await _repository.UpdateAsync(order);
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