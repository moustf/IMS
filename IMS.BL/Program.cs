using System;

namespace IMS.BL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var product = Inventory.AddNewProduct();
            
            var updatedProduct = Inventory.EditProductByName(product.ProductName);
            
            Console.WriteLine(updatedProduct.ProductName);
            Console.WriteLine(updatedProduct.ProductPrice);
            Console.WriteLine(updatedProduct.ProductQuantity);
        }
    }
}