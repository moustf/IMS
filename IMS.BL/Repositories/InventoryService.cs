using System.Collections.Generic;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public class InventoryService
    {
        private IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryService)
        {
            _inventoryRepository = inventoryService;
        }

        /// <summary>
        /// Appends a product into the database.
        /// </summary>
        /// <returns></returns>
        public void AddNewProduct(Product product)
        {
            _inventoryRepository.AddNewProduct(product);
        }

        /// <summary>
        /// Edit a product that exists in the database.
        /// </summary>
        /// <returns></returns>
        public void EditProduct(Product product)
        {
            _inventoryRepository.EditProduct(product);
        }

        /// <summary>
        /// Remove a product that exists in the database.
        /// </summary>
        /// <returns></returns>
        public void RemoveProduct(int id)
        {
            _inventoryRepository.RemoveProduct(id);
        }

        /// <summary>
        /// Retrieve all inventory products.
        /// </summary>
        /// <returns>List of products</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _inventoryRepository.GetAllProducts();
        }

        /// <summary>
        /// Retrieve one product from the inventory class.
        /// </summary>
        /// <returns>Product</returns>
        public Product GetOneProduct(int id)
        {
            return _inventoryRepository.GetOneProduct(id);
        }
    }
}