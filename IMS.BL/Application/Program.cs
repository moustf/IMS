﻿using System;
using System.Linq;
using IMS.BL.Database.DatabaseConnections.SqlDatabaseConnection;
using IMS.BL.Domain;
using IMS.BL.Repositories;

namespace IMS.BL.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please choose what operation you want to perform.");
            Console.WriteLine("1 --> Add New Product.");
            Console.WriteLine("2 --> Edit Existing Product.");
            Console.WriteLine("3 --> Delete Existing Product.");
            Console.WriteLine("4 --> Search For A Product.");
            Console.WriteLine("5 --> Get All Products.");
            Console.WriteLine("0 --> Exit.");
            
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please, enter a valid number from the choices above.");
            }           
            
            // Required objects.
            var sqlConnection = SqlConnectionProvider.Instance.SqlConnectionObject;
            var sqlInventoryRepository = new SqlInventoryRepository(sqlConnection);
            var inventoryRepository = new InventoryRepository();
            inventoryRepository.SetInventoryRepository(sqlInventoryRepository);
            var getProductData = new GetProductData();
            
            try
            {
                switch (choice)
                {
                    case 1:
                    {
                        var productData = getProductData.GetProductToAdd();
                        inventoryRepository.AddNewProduct(productData);
                    
                        Console.WriteLine($"The product has been added successfully!");
                        break;
                    }
                    case 2:
                    {
                        var product = getProductData.GetProductToModify();
                        inventoryRepository.EditProduct(product);
                    
                        Console.WriteLine($"The product has been updated successfully!");
                        break;
                    }
                    case 3:
                    {
                        var productId = getProductData.GetProductId();
                        inventoryRepository.RemoveProduct(productId);
                    
                        Console.WriteLine($"The product has been deleted successfully!");
                        
                        break;
                    }
                    case 4:
                    {
                        var productId = getProductData.GetProductId();
                        var product = inventoryRepository.GetOneProduct(productId);
                    
                        Console.WriteLine($"The product with id of: {product.Id} has a name of {product.Name}, its cost is {product.Price}, and {product.Quantity} products are available!");
                        break;
                    }
                    case 5:
                    {
                        var products = inventoryRepository.GetAllProducts();

                        if (!products.Any())
                        {
                            throw new NullReferenceException();
                        }
                    
                        Console.WriteLine("The list of the products you have is:");
                        foreach (var product in products)
                        {
                            Console.WriteLine($"The product with id of: {product.Id} has a name of {product.Name}, its cost is {product.Price}, and {product.Quantity} products are available!");
                        }
            
                        break;
                    }
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() == typeof(NullReferenceException)
                    ? "There are no products with the provided data!"
                    : "The data you entered is not valid, please try again and provide a valid data!");
                Environment.Exit(1);
            }
        }
    }
}