using System.Collections.Generic;
using System.Linq;

namespace IMS.BL
{
    public static class InventoryRepository
    {
        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List<string></returns>
        public static List<string> RetrieveAllProducts()
        {
            var productsList = Inventory.ProductsList;
            var stringProductsList = new List<string>();

            foreach (var product in productsList)
            {
                stringProductsList.Add(
                    $"Product num: {product.ProductId}, got a name of: {product.ProductName}, costs: {product.ProductPrice}, and we've got: {product.ProductQuantity} of it!"
                    );
            }

            return stringProductsList;
        }
        
        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>string</returns>
        public static string RetrieveOneProduct(string productName)
        {
            var product = Inventory.ProductsList.SingleOrDefault(prod => prod.ProductName == productName);
            
            if (product == null)
            {
                return "The product you are searching for doesn't exist on the inventory store!";
            }

            return
                $"Product num: {product.ProductId}, got a name of: {product.ProductName}, costs: {product.ProductPrice}, and we've got: {product.ProductQuantity} of it!";
        }
    }
}