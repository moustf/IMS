using System;

namespace IMS.BL
{
    public struct ProductInfo
    {
        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int ProductQuantity { get; private set; }

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