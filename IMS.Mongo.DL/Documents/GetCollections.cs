using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.Mongo.DL.Documents
{
    public class GetCollections
    {
        private MongoClient _mongoClient;

        public GetCollections(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }
        
        public IMongoCollection<BsonDocument> GetProductsCollection()
        {
            var imsDatabase = _mongoClient.GetDatabase("IMS");
            
            return imsDatabase.GetCollection<BsonDocument>("products");
        }
    }
}