using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.BL.Database.DatabaseConnections.MongoDatabaseConnection.DDL
{
    public class ProductCollection
    {
        private readonly MongoClient _mongoClient;

        public ProductCollection(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public IMongoCollection<BsonDocument> GetProductCollection()
        {
            var imsDatabase = _mongoClient.GetDatabase("IMS");

            return imsDatabase.GetCollection<BsonDocument>("products");
        }
    }
}