using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;

namespace IMS.BL
{
    public class Inventory
    {
        public Inventory()
        {
            ProductsList = new Dictionary<string, Product>();
        }

        public  Dictionary<string, Product> ProductsList { get; private set; }

        public  Product AddNewProduct(ProductData productData, Mapper mapper)
        {
            var product = mapper.Map<ProductData, Product>(productData);
            
            ProductsList.Add(productData.ProductName, product);

            return product;
        }

        public void EditProductByName(string productName, ProductData productData)
        {
            var product = ProductsList.Values.SingleOrDefault(prod => prod.ProductName == productName);

            if (product == null)
            {
                throw new NullReferenceException("No products can be found.");
            }
            
            product.ProductName = productData.ProductName;
            product.ProductPrice = productData.ProductPrice;
            product.ProductQuantity = productData.ProductQuantity;
        }

        public void RemoveProductByName(string productName)
        {
            var product = ProductsList.Values.SingleOrDefault(prod => prod.ProductName == productName);
            
            if (product == null)
            {
                throw new NullReferenceException("The product you are trying to delete does not exist.");
            }
            
            ProductsList.Remove(productName);
        }
    }
}