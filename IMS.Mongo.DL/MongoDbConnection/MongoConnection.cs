using MongoDB.Driver;

namespace IMS.Mongo.DL.MongoDbConnection
{
    public class MongoConnection
    {
        public MongoClient MongoClient { get; private set; }

        public MongoConnection(MongoClient mongoClient)
        {
            MongoClient = mongoClient;
        }
    }
}