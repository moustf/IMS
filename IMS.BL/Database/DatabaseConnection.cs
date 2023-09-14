using IMS.BL.Database.DatabaseConnections;

namespace IMS.BL.Database
{
    public class DatabaseConnection
    {
        private IDbTypeConnection _dbTypeConnection;

        public void SetDbTypeConnection(IDbTypeConnection dbTypeConnection)
        {
            _dbTypeConnection = dbTypeConnection;
        }

        public void SetConnection()
        {
            _dbTypeConnection.SetConnection();
        }
    }
}