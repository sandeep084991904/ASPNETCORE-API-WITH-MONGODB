
using MongoDBCrudExample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MongoDBCrudExample.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(string id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(string id, Item item);
        Task DeleteItemAsync(string id);
    }
}
