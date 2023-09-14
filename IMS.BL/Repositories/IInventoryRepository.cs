using System.Collections.Generic;
using System.Threading.Tasks;
using IMS.BL.Domain;

namespace IMS.BL.Repositories
{
    public interface IInventoryRepository
    {
        Task AddNewProduct(Product product);
        Task EditProduct(Product product);
        Task RemoveProduct(string productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetOneProduct(string productId);
    }
}