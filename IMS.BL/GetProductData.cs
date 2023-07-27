using System;

namespace IMS.BL
{
    public class GetProductData
    {
        public ProductData GetProductFromUserInput()
        {
            Console.WriteLine("Please specify the product name.");
            var productName = Console.ReadLine();
        
            Console.WriteLine("Please specify the product price.");
            var productPrice = decimal.Parse(Console.ReadLine() ?? "0");
        
            Console.WriteLine("Please specify the product quantity.");
            var productQuantity = int.Parse(Console.ReadLine() ?? "0");
        
            return new ProductData(productName, productPrice, productQuantity);
        }

        public string GetProductName()
        {
            Console.WriteLine("Please specify the product name you want to edit.");
            var productName = Console.ReadLine();

            return productName;
        }
    }
}