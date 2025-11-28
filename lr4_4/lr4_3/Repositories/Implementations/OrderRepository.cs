using MongoDB.Driver;
using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using SortTest.Test;

namespace lr4_3.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository()
        {
            _collection = MongoDBClient.Instance.GetCollection<Order>("Orders");
        }

        public async Task CreateAsync(Order order) =>
            await _collection.InsertOneAsync(order);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<Order>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Order?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Order order) =>
            await _collection.ReplaceOneAsync(x => x.Id == order.Id, order);
    }
}
