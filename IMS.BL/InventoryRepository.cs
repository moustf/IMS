using System.Collections.Generic;

namespace IMS.BL
{
    public class InventoryRepository
    {
        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> RetrieveAllProducts()
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
    }
}