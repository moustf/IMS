using System;

namespace IMS.BL.Database.DatabaseConnections.SqlDatabaseConnection
{
    public sealed class SqlConnectionProvider
    {
        private static readonly Lazy<MsSqlConnection> Lazy = new Lazy<MsSqlConnection>(() =>
            {
                var msSqlConnection = new MsSqlConnection();
                msSqlConnection.SetConnection();
                
                return msSqlConnection;
            }
        );

        public static readonly MsSqlConnection Instance = Lazy.Value;
        
        private SqlConnectionProvider() { }
    }
}