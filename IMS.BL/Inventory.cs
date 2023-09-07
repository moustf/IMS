using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;
using IMS.BL.DataService;
using IMS.DL.SqlDatabaseConnection;

namespace IMS.BL
{
    public class Inventory
    {
        private readonly DataAccess _dataAccess;
        public Inventory(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public  bool AddNewProduct(ProductData productData)
        {
            return _dataAccess.InsertProduct(productData);
        }

        public void EditProduct(int productId, ProductData productData)
        {
            var product = _dataAccess.UpdateProduct(productId, productData);

            if (product == null)
            {
                throw new NullReferenceException("No products can be found.");
            }
        }

        public void RemoveProduct(int productId)
        {
            var isDeleted = _dataAccess.DeleteProduct(productId);
            
            if (isDeleted == null)
            {
                throw new NullReferenceException("The product you are trying to delete does not exist.");
            }
        }
    }
}