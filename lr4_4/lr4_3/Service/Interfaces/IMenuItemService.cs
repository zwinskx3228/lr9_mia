using lr4_3.Models;

namespace lr4_3.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(string id);
        Task CreateAsync(MenuItem item);
        Task<bool> UpdateAsync(MenuItem item);
        Task<bool> DeleteAsync(string id);
    }
}