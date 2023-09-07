using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IMS.BL.DataService
{
    public class DataAccess
    {
        private readonly SqlConnection _sqlConnection;

        public DataAccess(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        
        public IEnumerable<Product> SelectAllProducts()
        {
            try
            {
                _sqlConnection.Open();
                
                var products = new List<Product>();
                
                const string sql = "SELECT id, name, price, quantity FROM product";
                var sqlCommand = new SqlCommand(sql, _sqlConnection);
                
                var dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    var product = new Product()
                    {
                        Id = int.Parse($"{dataReader.GetValue(0)}"),
                        Name = $"{dataReader.GetValue(1)}",
                        Price = decimal.Parse($"{dataReader.GetValue(2)}"),
                        Quantity = int.Parse($"{dataReader.GetValue(3)}")
                    };
                    products.Add(product);
                }

                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong happened when getting the data from the database: " + e.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public Product SelectOneProduct(int id)
        {
            try
            {
                _sqlConnection.Open();

                var product = new Product();
                const string sql = @"SELECT id, name, price, quantity FROM product WHERE id = @id";
                var sqlCommand = new SqlCommand(sql, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                
                var dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    product = new Product()
                    {
                        Id = int.Parse($"{dataReader.GetValue(0)}"),
                        Name = $"{dataReader.GetValue(1)}",
                        Price = decimal.Parse($"{dataReader.GetValue(2)}"),
                        Quantity = int.Parse($"{dataReader.GetValue(3)}")
                    };
                }
                
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong happened when getting the data from the database: " + e.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertProduct(ProductData product)
        {
            try
            {
                _sqlConnection.Open();

                var sqlAdapter = new SqlDataAdapter();

                var sql = @"INSERT INTO product(name, price, quantity) VALUES (@name, @price, @quantity)";
                var sqlCommand = new SqlCommand(sql, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", product.Name);
                sqlCommand.Parameters.AddWithValue("@price", product.Price);
                sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                
                sqlAdapter.InsertCommand = sqlCommand;
                sqlAdapter.InsertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong happened when getting the data from the database: " + e.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        
        public bool? UpdateProduct(int id, ProductData product)
        {
            try
            {
                _sqlConnection.Open();

                var sqlAdapter = new SqlDataAdapter();

                var sql = @"UPDATE product SET name = @name, price = @price, quantity = @quantity WHERE id = @id";
                var sqlCommand = new SqlCommand(sql, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@name", product.Name);
                sqlCommand.Parameters.AddWithValue("@price", product.Price);
                sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                
                sqlAdapter.UpdateCommand = sqlCommand;
                sqlAdapter.UpdateCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        
        public bool? DeleteProduct(int id)
        {
            try
            {
                _sqlConnection.Open();

                var sqlAdapter = new SqlDataAdapter();

                const string sql = @"DELETE product WHERE id = @id";
                var sqlCommand = new SqlCommand(sql, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                
                sqlAdapter.DeleteCommand = sqlCommand;
                sqlAdapter.DeleteCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}