using System.Data.SqlClient;

namespace IMS.DL.SqlDatabaseConnection
{
    public class MsSqlConnection
    {
        public SqlConnection SqlConnectionObject { get; set; }

        public MsSqlConnection(SqlConnection sqlConnection)
        {
            SqlConnectionObject = sqlConnection;
        }
    }
}