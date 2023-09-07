using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using IMS.BL.DataService;
using IMS.DL.SqlDatabaseConnection;

namespace IMS.BL
{
    public class InventoryRepository
    {
        private DataAccess _dataAccess;

        public InventoryRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List of strings</returns>
        public IEnumerable<string> GetAllProducts()
        {
            var products = _dataAccess.SelectAllProducts();

            var stringProductsList = products.Select(product => 
                $"Product num: {product.Id}, got a name of: {product.Name}, costs: {product.Price}, and we've got: {product.Quantity} of it!"
            );

            return stringProductsList;
        }
        
        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>string</returns>
        public string SearchForOneProduct(int productId)
        {
            var product = _dataAccess.SelectOneProduct(productId);
            
            if (product == null)
            {
                throw new NullReferenceException("No products can be found.");
            }

            return
                $"Product num: {product.Id}, got a name of: {product.Name}, costs: {product.Price}, and we've got: {product.Quantity} of it!";
        }
    }
}