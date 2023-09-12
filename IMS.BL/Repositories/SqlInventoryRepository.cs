using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public class SqlInventoryRepository : IInventoryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public SqlInventoryRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(sqlConnection), "sqlConnection cannot be null.");
        }
        
        public void AddNewProduct(Product product)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            var sql = @"INSERT INTO product(name, price, quantity) VALUES (@Name, @Price, @Quantity)";
            
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@price", product.Price);
            sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                
            sqlAdapter.InsertCommand = sqlCommand;
            sqlAdapter.InsertCommand.ExecuteNonQuery();
        }
        
        public void EditProduct(Product product)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            var sql = @"UPDATE product SET name = @Name, price = @Price, quantity = @Quantity WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", product.Id);
            sqlCommand.Parameters.AddWithValue("@Name", product.Name);
            sqlCommand.Parameters.AddWithValue("@Price", product.Price);
            sqlCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                
            sqlAdapter.UpdateCommand = sqlCommand;
            sqlAdapter.UpdateCommand.ExecuteNonQuery();
        }
        
        public void RemoveProduct(int id)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            const string sql = @"DELETE product WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
                
            sqlAdapter.DeleteCommand = sqlCommand;
            sqlAdapter.DeleteCommand.ExecuteNonQuery();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            _sqlConnection.Open();
                
            var products = new List<Product>();
                
            const string sql = "SELECT id, name, price, quantity FROM product";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
                
            var dataReader = sqlCommand.ExecuteReader();
            
            if (!dataReader.HasRows)
            {
                
                return new List<Product>();
            }
            
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
            
            _sqlConnection.Close();

            return products;
        }
        
        public Product GetOneProduct(int id)
        {
            _sqlConnection.Open();

            var product = new Product();
            const string sql = @"SELECT id, name, price, quantity FROM product WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
                
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
    }
}