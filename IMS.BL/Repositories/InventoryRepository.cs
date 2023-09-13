using System.Collections.Generic;
using System.Threading.Tasks;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public class InventoryRepository
    {
        private IInventoryService _inventoryService;

        public void SetInventoryRepository(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Appends a product into the database.
        /// </summary>
        /// <returns></returns>
        public async Task AddNewProduct(Product product)
        {
            await _inventoryService.AddNewProduct(product);
        }

        /// <summary>
        /// Edit a product that exists in the database.
        /// </summary>
        /// <returns></returns>
        public async Task EditProduct(Product product)
        {
            await _inventoryService.EditProduct(product);
        }

        /// <summary>
        /// Remove a product that exists in the database.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveProduct(string id)
        {
            await _inventoryService.RemoveProduct(id);
        }

        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _inventoryService.GetAllProducts();
        }

        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>Product</returns>
        public async Task<Product> GetOneProduct(string id)
        {
            return await _inventoryService.GetOneProduct(id);
        }
    }
}