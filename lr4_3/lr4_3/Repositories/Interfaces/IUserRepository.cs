using lr4_3.Models;

namespace lr4_3.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
    }
}