using System;
using System.Threading.Tasks;
using IMS.BL.DataService;

namespace IMS.BL
{
    public class Inventory
    {
        private readonly DataAccess _dataAccess;
        public Inventory(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public  async Task<bool> AddNewProduct(ProductData productData)
        {
            return await _dataAccess.InsetProduct(productData);
        }

        public async Task<bool> EditProductByName(string productId, ProductData productData)
        {
            var isUpdated = await _dataAccess.UpdateProduct(productId, productData);
            
            if (!isUpdated)
            {
                throw new NullReferenceException("No products can be found.");
            }

            return isUpdated;
        }

        public async Task<bool> RemoveProduct(string productId)
        {
            var isDeleted = await _dataAccess.DeleteProduct(productId);
            
            if (!isDeleted)
            {
                throw new NullReferenceException("The product you are trying to delete does not exist.");
            }

            return isDeleted;
        }
    }
}