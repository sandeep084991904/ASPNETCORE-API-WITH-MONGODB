using MongoDB.Driver;
using MongoDBCrudExample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MongoDBCrudExample.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> _items;
        public ItemRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<Item>("Items");
        }
        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _items.Find(item => true).ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(string id)
        {
            return await _items.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateItemAsync(Item item)
        {
            await _items.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(string id, Item item)
        {
            await _items.ReplaceOneAsync(item => item.Id == id, item);
        }

        public async Task DeleteItemAsync(string id)
        {
            await _items.DeleteOneAsync(item => item.Id == id);
        }
    }
}
