using MongoDB.Driver;
using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using SortTest.Test;

namespace lr4_3.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository()
        {
            _collection = MongoDBClient.Instance.GetCollection<User>("Users");
        }

        public async Task CreateAsync(User user) =>
            await _collection.InsertOneAsync(user);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<User>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(User user) =>
            await _collection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }
}