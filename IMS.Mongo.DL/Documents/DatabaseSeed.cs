using System.Threading.Tasks;
using IMS.Mongo.DL.MongoDbConnection;
using MongoDB.Bson;

namespace IMS.Mongo.DL.Documents
{
    public class DatabaseSeed
    {
        public async Task SeedDatabase()
        {
            var dbClient = MongoConnectionProvider.Instance.MongoClient;

            var imsDatabase = dbClient.GetDatabase("IMS");
            var productsDocument = imsDatabase.GetCollection<BsonDocument>("products");

            var product1 = new BsonDocument
            {
                { "name", "Coffee Machine" },
                { "price", 599.99 },
                { "quantity", 4 }
            };
            var product2 = new BsonDocument
            {
                { "name", "Blinder" },
                { "price", 255.88 },
                { "quantity", 3 }
            };
            
            await productsDocument.InsertManyAsync(new []{ product1, product2 });
        }
    }
}