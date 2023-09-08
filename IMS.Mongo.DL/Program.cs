using System;
using System.Threading.Tasks;
using IMS.Mongo.DL.Documents;
using IMS.Mongo.DL.MongoDbConnection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.Mongo.DL
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var dbClient = MongoConnectionProvider.Instance.MongoClient;

            var getCollections = new GetCollections(dbClient);
            
            var productsCollection = getCollections.GetProductsCollection();

            var products = await productsCollection.FindAsync(new BsonDocument());

            foreach (var product in products.ToList())
            {
                Console.WriteLine(product);
            }
        }
    }
}