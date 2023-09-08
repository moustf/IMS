using System;

namespace IMS.Mongo.DL.MongoDbConnection
{
    public sealed class MongoConnectionProvider
    {
        private static readonly MongoConnectionFactory MongoConnectionFactory = new MongoConnectionFactory();

        private static readonly Lazy<MongoConnection> Lazy =
            new Lazy<MongoConnection>(() => MongoConnectionFactory.CreateMongoConnection());

        public static MongoConnection Instance = Lazy.Value;
        
        private MongoConnectionProvider() { }
    }
}