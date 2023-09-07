using System;

namespace IMS.DL.SqlDatabaseConnection
{
    public sealed class SqlConnectionProvider
    {
        private static readonly SqlConnectionFactory SqlConnectionFactory = new SqlConnectionFactory();
        
        private static readonly Lazy<MsSqlConnection> Lazy = new Lazy<MsSqlConnection>(() =>
            SqlConnectionFactory.CreateSqlConnection()
        );

        public static MsSqlConnection Instance = Lazy.Value;
        
        private SqlConnectionProvider() { }
    }
}