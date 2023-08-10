using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.BL
{
    public class InventoryRepository
    {
        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List of strings</returns>
        public IEnumerable<string> GetAllProducts(Dictionary<string, Product> productsList)
        {
            var products = productsList.Values;

            var stringProductsList = products.Select(product => 
                $"Product num: {product.ProductId}, got a name of: {product.ProductName}, costs: {product.ProductPrice}, and we've got: {product.ProductQuantity} of it!"
            );

            return stringProductsList;
        }
        
        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>string</returns>
        public string SearchForOneProduct(string productName, Dictionary<string, Product> productsList)
        {
            var products = productsList.Values;
            var product = products.SingleOrDefault(prod => prod.ProductName == productName);
            
            if (product == null)
            {
                throw new NullReferenceException("No products can be found.");
            }

            return
                $"Product num: {product.ProductId}, got a name of: {product.ProductName}, costs: {product.ProductPrice}, and we've got: {product.ProductQuantity} of it!";
        }
    }
}