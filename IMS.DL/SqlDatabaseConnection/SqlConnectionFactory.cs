using System.Data.SqlClient;

namespace IMS.DL.SqlDatabaseConnection
{
    public class SqlConnectionFactory
    {
        public MsSqlConnection CreateSqlConnection()
        {
            const string connectionString = @"Data Source=hazza;Initial Catalog=IMS;User Id=sa;Password=Root@123";
            var sqlConnection = new SqlConnection(connectionString);

            return new MsSqlConnection(sqlConnection);
        }
    }
}