using System.Data.SqlClient;

namespace IMS.BL.Database.DatabaseConnections.SqlDatabaseConnection
{
    public class MsSqlConnection : IDbTypeConnection
    {
        public SqlConnection SqlConnectionObject { get; set; }

        public void SetConnection()
        {
            const string connectionString = @"Data Source=hazza;Initial Catalog=IMS;User Id=sa;Password=Root@123";
            
            var sqlConnection = new SqlConnection(connectionString);
            SqlConnectionObject = sqlConnection;
        }
    }
}