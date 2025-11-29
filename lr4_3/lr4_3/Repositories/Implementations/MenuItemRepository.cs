using MongoDB.Driver;
using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using SortTest.Test;

namespace lr4_3.Repositories.Implementations
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly IMongoCollection<MenuItem> _collection;

        public MenuItemRepository()
        {
            _collection = MongoDBClient.Instance.GetCollection<MenuItem>("MenuItems");
        }

        public async Task CreateAsync(MenuItem item) =>
            await _collection.InsertOneAsync(item);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<MenuItem>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<MenuItem?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(MenuItem item) =>
            await _collection.ReplaceOneAsync(x => x.Id == item.Id, item);
    }
}
