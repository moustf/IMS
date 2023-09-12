using System;

namespace IMS.BL.Domain
{
    public class GetProductData
    {
        public ProductData GetProductDataExceptId()
        {
            Console.WriteLine("Please specify the product name.");
            var productName = Console.ReadLine();
        
            Console.WriteLine("Please specify the product price.");
            var productPrice = decimal.Parse(Console.ReadLine() ?? "0");
        
            Console.WriteLine("Please specify the product quantity.");
            var productQuantity = int.Parse(Console.ReadLine() ?? "0");

            return new ProductData(productName, productPrice, productQuantity);
        }
        
        public Product GetProductToModify()
        {
            Console.WriteLine("Please specify the product id you choose to perform the operation on.");
            var productId = int.Parse(Console.ReadLine() ?? "0");

            var productData = GetProductDataExceptId();

            return new Product()
            {
                Id = productId,
                Name = productData.Name,
                Price = productData.Price,
                Quantity = productData.Quantity,
            };
        }
        
        public Product GetProductToAdd()
        {
            var productData = GetProductDataExceptId();

            return new Product()
            {
                Name = productData.Name,
                Price = productData.Price,
                Quantity = productData.Quantity,
            };
        }

        public int GetProductId()
        {
            Console.WriteLine("Please specify the product id you choose to perform the operation on.");
            var productId = int.Parse(Console.ReadLine() ?? "0");

            return productId;
        }
    }
}