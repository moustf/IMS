
// delete unnecessary dependencies 
//Keeping them would slower your application completion time
// and that on a 10k line application and bigger is a crucial time
// and they are adding lines without any value (which we dont want to have)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

namespace IMS.BL
{
    public static class Inventory
    {
        // why static 
        set<Product>
        static Inventory()
        {
            ProductsList = new List<Product>();
        }

        // why using list, using a hashtable data structure is more suitable for this task like dictionary  
        public static List<Product> ProductsList { get; private set; }

        // do not use static method as your to go approach of building methods
        // in real life we avoid static methods, static fields, static classes on all const
        // because its not asyncrunas safe by default and not aligning with testing concepts
        // list unit test which is built on the isolation of that unit which is being violated by the static method
        public static Product AddNewProduct(ProductInfo productInfo)
        {
            // why not pass the product into object instead of accessing it through static method
            // this intriduces a lot of issues for a complex application
            // and not aligning with the unit testing concepts
            //var productInfo = ProductInfo.GetProductFromUserInput();

            // (optional) you can use automapper for mapping properties between 2 objects
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
            // same as AddNewProduct
            var productInfo = ProductInfo.GetProductFromUserInput();
            product.ProductName = productInfo.ProductName;
            product.ProductPrice = productInfo.ProductPrice;
            product.ProductQuantity = productInfo.ProductQuantity;

            return product;
        }

        public static int RemoveProductByName(string productName)
        {
            var product = ProductsList.SingleOrDefault(prod => prod.ProductName == productName);

            // why using -1,1 we should handle the null properly
            // send back the null to the caller to handel it or throw an excpetion 
            if (product == null)
            {
                return -1;
            }
            
            ProductsList.RemoveAt(ProductsList.FindIndex(prod => prod.ProductName == productName));

            return 1;
        }
    }
}