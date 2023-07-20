using System;
using NUnit.Framework;
using IMS.BL;

namespace IMS.BLTest
{
    [TestFixture]
    public class InventoryTest
    {
        [Test]
        public void AddNewProductValid()
        {
            // -- Arrange.
            const string productName = "Coffee Machine";
            const decimal productPrice = 245.99M;
            const int productQuantity = 2;
            
            var reader = new System.IO.StringReader($"{productName}\n{productPrice}\n{productQuantity}\n");
            Console.SetIn(reader);
            
            var product = Inventory.AddNewProduct();
            
            // -- Act.
            var actual = new Product()
            {
                ProductName = productName,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,
            };
            
            // -- Assert.
            Assert.AreEqual(product.ProductName, actual.ProductName);
            Assert.AreEqual(product.ProductPrice, actual.ProductPrice);
            Assert.AreEqual(product.ProductQuantity, actual.ProductQuantity);
        }
    }
}