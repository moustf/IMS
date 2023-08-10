using System;

namespace IMS.BL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please choose what operation you want to perform.");
            Console.WriteLine("1 --> Add New Product.");
            Console.WriteLine("2 --> Edit Existing Product.");
            Console.WriteLine("3 --> Search For A Product.");
            Console.WriteLine("4 --> Get All Products.");
            Console.WriteLine("0 --> Exit.");
            
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please, enter a valid number from the choices above.");
            }           
            
            // Required objects.
            var mapperConfig = new MapperConfig();
            var mapper = mapperConfig.InitializeAutomapper();
            var inventory = new Inventory();
            var inventoryRepository = new InventoryRepository();
            var getProductData = new GetProductData();

            try
            {
                switch (choice)
                {
                    case 1:
                    {
                        var productData = getProductData.GetProductFromUserInput();
                        var product = inventory.AddNewProduct(productData, mapper);
                    
                        Console.WriteLine($"Product {product.ProductName} is added successfully!");
                        break;
                    }
                    case 2:
                    {
                        var productName = getProductData.GetProductName();
                        var productData = getProductData.GetProductFromUserInput();
                        inventory.EditProductByName(productName, productData);
                    
                        Console.WriteLine($"Product {productName} got edited successfully!");
                        break;
                    }
                    case 3:
                    {
                        var productName = getProductData.GetProductName();
                        var productsList = inventory.ProductsList;
                        var productString = inventoryRepository.SearchForOneProduct(productName, productsList);
                    
                        Console.WriteLine($"The product you are searching for: {productString}");
                        break;
                    }
                    case 4:
                    {
                        var productsList = inventory.ProductsList;
                        var products = inventoryRepository.GetAllProducts(productsList);
                    
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
                Console.WriteLine("The data you entered is not valid, please try again and provide a valid data!");
                Environment.Exit(1);
            }
        }
    }
}

// while (!int.TryParse(Console.ReadLine(), out productInfoProductQuantity))
// {
//     Console.WriteLine("Enter a valid product quantity, please.");
// }
// productInfo.ProductQuantity = productInfoProductQuantity;

// while (!decimal.TryParse(Console.ReadLine(), out productInfoProductPrice))
// {
//     Console.WriteLine("Enter a valid product price, please.");
// }
// productInfo.ProductPrice = productInfoProductPrice;

// while (string.IsNullOrWhiteSpace(productInfo.ProductName))
// {
//     Console.WriteLine("Enter a valid product name, please.");
//     productInfo.ProductName = Console.ReadLine();
// }
