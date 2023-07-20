using System;

namespace IMS.BL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please specify the product name.");
            var productName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Enter a valid product name, please.");
                productName = Console.ReadLine();
            }
            
            Console.WriteLine("Please specify the product price.");
            decimal productPrice;
            while (!decimal.TryParse(Console.ReadLine(), out productPrice))
            {
                Console.WriteLine("Enter a valid product price, please.");
            }
            
            Console.WriteLine("Please specify the product quantity.");
            int productQuantity;
            while (!int.TryParse(Console.ReadLine(), out productQuantity))
            {
                Console.WriteLine("Enter a valid product quantity, please.");
            }

            var product = new Product()
            {
                ProductName = productName,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,

            };
            
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.ProductPrice);
            Console.WriteLine(product.ProductQuantity);
        }
    }
}