using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using lr4_3.Services.Interfaces;

namespace lr4_3.Services.Implementations
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateAsync(MenuItem item)
        {
            await _repository.CreateAsync(item);
        }

        public async Task<bool> UpdateAsync(MenuItem item)
        {
            var existing = await _repository.GetAsync(item.Id);
            if (existing == null)
                return false;

            await _repository.UpdateAsync(item);
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