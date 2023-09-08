using MongoDB.Driver;

namespace IMS.Mongo.DL.MongoDbConnection
{
    public class MongoConnectionFactory
    {
        public MongoConnection CreateMongoConnection()
        {
            const string connectionString = @"mongodb+srv://hazza:root123@ims.i3nvgo7.mongodb.net/?retryWrites=true&w=majority";

            var mongoClient = new MongoClient(connectionString);

            return new MongoConnection(mongoClient);
        }
    }
}