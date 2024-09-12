using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBCrudExample.Models
{
    public class Item
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
}
