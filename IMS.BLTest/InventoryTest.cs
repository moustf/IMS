﻿using System;
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
            const string productName = "T-Shirt";
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

        [Test]
        public void EditProductByProductNameValid()
        {
            // -- Arrange.
            var productName = "Jacket";
            var productPrice = 245.99M;
            var productQuantity = 2;
            var reader = new System.IO.StringReader($"{productName}\n{productPrice}\n{productQuantity}\n");
            Console.SetIn(reader);
            
            var product = Inventory.AddNewProduct();
            
            productName = "Sweater";
            productPrice = 2445.99M;
            productQuantity = 26;
            reader = new System.IO.StringReader($"{productName}\n{productPrice}\n{productQuantity}\n");
            Console.SetIn(reader);
            var updatedProduct = Inventory.EditProductByName(product.ProductName);
        
            // -- Act.
            var mockedUpdatedProduct = new Product()
            {
                ProductName = productName,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,
            };
            
            // -- Assert.
            Assert.AreEqual(updatedProduct.ProductName, mockedUpdatedProduct.ProductName);
            Assert.AreEqual(updatedProduct.ProductPrice, mockedUpdatedProduct.ProductPrice);
            Assert.AreEqual(updatedProduct.ProductQuantity, mockedUpdatedProduct.ProductQuantity);
        }
        
        [Test]
        public void EditProductByProductNameInvalid()
        {
            // -- Arrange.
            var updatedProduct = Inventory.EditProductByName("");
        
            // -- Act.
            
            // -- Assert.
            Assert.AreEqual(updatedProduct, null);
        }
        
        [Test]
        public void RemoveProductByProductNameValid()
        {
            // -- Arrange.
            const string productName = "Shorts";
            const decimal productPrice = 12.50M;
            const int productQuantity = 3;
            var reader = new System.IO.StringReader($"{productName}\n{productPrice}\n{productQuantity}\n");
            Console.SetIn(reader);
            
            var product = Inventory.AddNewProduct();
            var listLengthBeforeDeletion = Inventory.ProductsList.Count;
            
            var isSuccess = Inventory.RemoveProductByName(product.ProductName);

            // -- Act.
            const int actual = 1;
            var listLengthAfterDeletion = Inventory.ProductsList.Count;
            
            // -- Assert.
            Assert.AreEqual(isSuccess, actual);
            Assert.AreEqual(listLengthAfterDeletion, (listLengthBeforeDeletion - 1));
        }
        
        
        [Test]
        public void RemoveProductByProductNameInvalid()
        {
            // -- Arrange.
            var isSuccess = Inventory.RemoveProductByName("");

            // -- Act.
            const int actual = -1;
            
            // -- Assert.
            Assert.AreEqual(isSuccess, actual);
        }
    }
}