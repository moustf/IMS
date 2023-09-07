using System;
using IMS.BL.DataService;
using IMS.DL.SqlDatabaseConnection;

namespace IMS.BL
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
            var dataAccess = new DataAccess(SqlConnectionProvider.Instance.SqlConnectionObject);
            var mapperConfig = new MapperConfig();
            var inventory = new Inventory(dataAccess);
            var inventoryRepository = new InventoryRepository(dataAccess);
            var getProductData = new GetProductData();
            
            try
            {
                switch (choice)
                {
                    case 1:
                    {
                        var productData = getProductData.GetProductFromUserInput();
                        var isAdded = inventory.AddNewProduct(productData);
                    
                        if (isAdded) Console.WriteLine($"The product has been added successfully!");
                        break;
                    }
                    case 2:
                    {
                        var productId = getProductData.GetProductId();
                        var productData = getProductData.GetProductFromUserInput();
                        inventory.EditProduct(productId, productData);
                    
                        Console.WriteLine($"The product has been updated successfully!");
                        break;
                    }
                    case 3:
                    {
                        var productId = getProductData.GetProductId();
                        inventory.RemoveProduct(productId);
                    
                        Console.WriteLine($"The product has been deleted successfully!");
                        
                        break;
                    }
                    case 4:
                    {
                        var productId = getProductData.GetProductId();
                        var productString = inventoryRepository.SearchForOneProduct(productId);
                    
                        Console.WriteLine($"The product you are searching for: {productString}");
                        break;
                    }
                    case 5:
                    {
                        var products = inventoryRepository.GetAllProducts();
                    
                        Console.WriteLine("The list of the products you have is:");
                        foreach (var product in products)
                        {
                            Console.WriteLine(product);
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
                if (e.GetType() == typeof(NullReferenceException))
                {
                    Console.WriteLine("There are no products with the provided data!");
                }
                
                Console.WriteLine("The data you entered is not valid, please try again and provide a valid data!");
                Environment.Exit(1);
            }
        }
    }
}
