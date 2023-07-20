using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.BL
{
    public static class Inventory
    {
        static Inventory()
        {
            ProductsList = new List<Product>();
        }

        public static List<Product> ProductsList { get; private set; }

        public static Product AddNewProduct()
        {
            var productInfo = ProductInfo.GetProductFromUserInput();

            var product = new Product()
            {
                ProductName = productInfo.ProductName,
                ProductPrice = productInfo.ProductPrice,
                ProductQuantity = productInfo.ProductQuantity,

            };
            
            ProductsList.Add(product);

            return product;
        }

        public static Product EditProductByName(string productName)
        {
            var product = ProductsList.SingleOrDefault(prod => prod.ProductName == productName);

            if (product == null)
            {
                return null;
            }
            
            var productInfo = ProductInfo.GetProductFromUserInput();
            product.ProductName = productInfo.ProductName;
            product.ProductPrice = productInfo.ProductPrice;
            product.ProductQuantity = productInfo.ProductQuantity;

            return product;
        }
    }
}