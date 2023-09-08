using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.BL.DataService;

namespace IMS.BL
{
    public class InventoryRepository
    {
        private readonly DataAccess _dataAccess;

        public InventoryRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List of strings</returns>
        public async Task<IEnumerable<string>> GetAllProducts()
        {
            var products = await _dataAccess.GetAllProducts();

            var stringProductsList = products.Select(product => 
                $"Product num: {product.Id}, got a name of: {product.Name}, costs: {product.Price}, and we've got: {product.Quantity} of it!"
            );

            return stringProductsList;
        }
        
        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> SearchForOneProduct(string productId)
        {
            var product = await _dataAccess.GetOneProduct(productId);
            
            if (product == null)
            {
                throw new NullReferenceException("No products can be found.");
            }

            return
                $"Product num: {product.Id}, got a name of: {product.Name}, costs: {product.Price}, and we've got: {product.Quantity} of it!";
        }
    }
}