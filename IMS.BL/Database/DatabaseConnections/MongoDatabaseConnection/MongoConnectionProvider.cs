using SharpCompress;

namespace IMS.BL.Database.DatabaseConnections.MongoDatabaseConnection
{
    public class MongoConnectionProvider
    {
        private static readonly Lazy<MongoConnection> Lazy = new Lazy<MongoConnection>(() =>
        {
            var mongoConnection = new MongoConnection();
            mongoConnection.SetConnection();

            return mongoConnection;
        });

        public static readonly MongoConnection Instance = Lazy.Value;
        
        private MongoConnectionProvider() {  }
    }
}