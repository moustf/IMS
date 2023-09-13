using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public class SqlInventoryService : IInventoryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public SqlInventoryService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(sqlConnection), "sqlConnection cannot be null.");
        }
        
        public async Task AddNewProduct(Product product)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            var sql = @"INSERT INTO product(name, price, quantity) VALUES (@Name, @Price, @Quantity)";
            
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@price", product.Price);
            sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                
            sqlAdapter.InsertCommand = sqlCommand;
            await sqlAdapter.InsertCommand.ExecuteNonQueryAsync();
        }
        
        public async Task EditProduct(Product product)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            var sql = @"UPDATE product SET name = @Name, price = @Price, quantity = @Quantity WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", int.Parse(product.Id));
            sqlCommand.Parameters.AddWithValue("@Name", product.Name);
            sqlCommand.Parameters.AddWithValue("@Price", product.Price);
            sqlCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                
            sqlAdapter.UpdateCommand = sqlCommand;
            await sqlAdapter.UpdateCommand.ExecuteNonQueryAsync();
        }
        
        public async Task RemoveProduct(string id)
        {
            _sqlConnection.Open();

            var sqlAdapter = new SqlDataAdapter();

            const string sql = @"DELETE product WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", int.Parse(id));
                
            sqlAdapter.DeleteCommand = sqlCommand;
            await sqlAdapter.DeleteCommand.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Product>>GetAllProducts()
        {
            _sqlConnection.Open();
                
            var products = new List<Product>();
                
            const string sql = "SELECT id, name, price, quantity FROM product";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
                
            var dataReader = await sqlCommand.ExecuteReaderAsync();
            
            if (!dataReader.HasRows)
            {
                
                return new List<Product>();
            }
            
            while (dataReader.Read())
            {
                var product = new Product()
                {
                    Id = $"{dataReader.GetValue(0)}",
                    Name = $"{dataReader.GetValue(1)}",
                    Price = decimal.Parse($"{dataReader.GetValue(2)}"),
                    Quantity = int.Parse($"{dataReader.GetValue(3)}")
                };
                products.Add(product);
            }
            
            _sqlConnection.Close();

            return products;
        }
        
        public async Task<Product> GetOneProduct(string id)
        {
            _sqlConnection.Open();

            var product = new Product();
            const string sql = @"SELECT id, name, price, quantity FROM product WHERE id = @Id";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", int.Parse(id));
                
            var dataReader = await sqlCommand.ExecuteReaderAsync();

            if (dataReader.Read())
            {
                product = new Product()
                {
                    Id = $"{dataReader.GetValue(0)}",
                    Name = $"{dataReader.GetValue(1)}",
                    Price = decimal.Parse($"{dataReader.GetValue(2)}"),
                    Quantity = int.Parse($"{dataReader.GetValue(3)}")
                };
            }
                
            return product;
        }
    }
}