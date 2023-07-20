using NUnit.Framework;
using IMS.BL;
using System;

namespace IMS.BLTest
{
    [TestFixture]
    public class InventoryRepositoryTest
    {
        [Test]
        public void RetrieveAllProductsValid()
        {
            // -- Arrange.
            var reader = new System.IO.StringReader("Coffee Machine\n44.5\n4\n");
            Console.SetIn(reader);
            Inventory.AddNewProduct();
            
            reader = new System.IO.StringReader("Toast Machine\n156.5\n2\n");
            Console.SetIn(reader);
            Inventory.AddNewProduct();
            
            var stringProductList = new InventoryRepository().RetrieveAllProducts();

            // -- Act.
            const string productStringOne =
                "Product num: 1, got a name of: Coffee Machine, costs: 44.5, and we've got: 4 of it!";
            const string productStringTwo =
                "Product num: 2, got a name of: Toast Machine, costs: 156.5, and we've got: 2 of it!";
            
            // -- Assert.
            Assert.AreEqual(
                stringProductList[0],
                productStringOne
                );
            Assert.AreEqual(
                stringProductList[1],
                productStringTwo
            );
        }
    }
}