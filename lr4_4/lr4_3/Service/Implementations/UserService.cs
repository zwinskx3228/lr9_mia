using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using lr4_3.Services.Interfaces;

namespace lr4_3.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var existing = await _repository.GetAsync(user.Id);
            if (existing == null)
                return false;

            await _repository.UpdateAsync(user);
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