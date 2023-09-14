using MongoDB.Driver;

namespace IMS.BL.Database.DatabaseConnections.MongoDatabaseConnection
{
    public class MongoConnection : IDbTypeConnection
    {
        public MongoClient MongoClient { get; private set; }
        
        public void SetConnection()
        {
            const string connectionString = @"mongodb+srv://hazza:root123@ims.i3nvgo7.mongodb.net/?retryWrites=true&w=majority";

            var mongoClient = new MongoClient(connectionString);

            MongoClient = mongoClient;
        }
    }
}