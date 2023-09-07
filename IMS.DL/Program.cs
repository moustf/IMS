using System;
using System.Data;
using System.Data.SqlClient;
using IMS.DL.SqlDatabaseConnection;

namespace IMS.DL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sqlConnection = SqlConnectionProvider.Instance.SqlConnectionObject;

            try
            {
                sqlConnection.Open();

                Console.WriteLine(sqlConnection.State == ConnectionState.Open);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}