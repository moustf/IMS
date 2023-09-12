using System.Collections.Generic;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public interface IInventoryRepository
    {
        void AddNewProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        Product GetOneProduct(int productId);
    }
}