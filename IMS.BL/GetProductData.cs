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

        public int GetProductId()
        {
            Console.WriteLine("Please specify the product id you want to edit.");
            var productId = int.Parse(Console.ReadLine() ?? "0");

            return productId;
        }
    }
}