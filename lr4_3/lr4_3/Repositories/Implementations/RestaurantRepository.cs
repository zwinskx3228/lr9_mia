using MongoDB.Driver;
using lr4_3.Models;
using lr4_3.Repositories.Interfaces;
using SortTest.Test;

namespace lr4_3.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<Restaurant> _collection;

        public RestaurantRepository()
        {
            _collection = MongoDBClient.Instance.GetCollection<Restaurant>("Restaurants");
        }

        public async Task CreateAsync(Restaurant restaurant) =>
            await _collection.InsertOneAsync(restaurant);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<Restaurant>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Restaurant?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Restaurant restaurant) =>
            await _collection.ReplaceOneAsync(x => x.Id == restaurant.Id, restaurant);
    }
}
