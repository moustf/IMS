using System;

namespace IMS.BL
{
    // why using struct ? 
    // for such models that carry data and that all its job you can use record
    // record is immutable and for one way flow, also simple
    // struct has a data size limit of 16 bytes and it is not for complex models like this one 
    //public record Person(string ProductName, decimal ProductPrice, string ProductQuantity);

    public struct ProductInfo
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        // single responsibility violation, models and DTOs (models that carry data between class / layers of the application)
        // should not include logic that is not part of there concerns 
        // this should only be a DTO, a career of data with no methods at all and not static once in particular 

        // move all of this into another class, maybe the program ? 
        public static ProductInfo GetProductFromUserInput()
        {
            var productInfo = new ProductInfo();
            
            Console.WriteLine("Please specify the product name.");
            productInfo.ProductName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(productInfo.ProductName))
            {
                Console.WriteLine("Enter a valid product name, please.");
                productInfo.ProductName = Console.ReadLine();
            }

            Console.WriteLine("Please specify the product price.");
            decimal productInfoProductPrice;
            while (!decimal.TryParse(Console.ReadLine(), out productInfoProductPrice))
            {
                Console.WriteLine("Enter a valid product price, please.");
            }
            productInfo.ProductPrice = productInfoProductPrice;

            Console.WriteLine("Please specify the product quantity.");
            int productInfoProductQuantity;
            while (!int.TryParse(Console.ReadLine(), out productInfoProductQuantity))
            {
                Console.WriteLine("Enter a valid product quantity, please.");
            }
            productInfo.ProductQuantity = productInfoProductQuantity;

            return productInfo;
        }
    }
}