using lr4_3.Models;

namespace lr4_3.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task CreateAsync(MenuItem item);
        Task<List<MenuItem>> GetAsync();
        Task<MenuItem?> GetAsync(string id);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(string id);
    }
}