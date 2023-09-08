using System;
using System.Threading.Tasks;
using IMS.BL.DataService;
using IMS.Mongo.DL.Documents;
using IMS.Mongo.DL.MongoDbConnection;

namespace IMS.BL
{
    internal class Program
    {
        public static async Task Main(string[] args)
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
            var mongoClient = MongoConnectionProvider.Instance.MongoClient;
            var productsDocument = new GetCollections(mongoClient).GetProductsCollection();
            var dataAccess = new DataAccess(productsDocument);
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
                        var isInserted = await inventory.AddNewProduct(productData);

                        Console.WriteLine(isInserted
                            ? $"The product has been added successfully!"
                            : $"Something went wrong while adding the product.");
                        break;
                    }
                    case 2:
                    {
                        var productId = getProductData.GetProductId();
                        var productData = getProductData.GetProductFromUserInput();
                        var isUpdated = await inventory.EditProductByName(productId, productData);
                    
                        if (isUpdated) Console.WriteLine($"The product has been edited successfully!");
                        break;
                    }
                    case 3:
                    {
                        var productId = getProductData.GetProductId();
                        var isDeleted = await inventory.RemoveProduct(productId);

                        Console.WriteLine(isDeleted
                            ? "The product has been deleted successfully"
                            : "Something wrong happened while deleting the product!");

                        break;
                    }
                    case 4:
                    {
                        var productId = getProductData.GetProductId();
                        var productString = await inventoryRepository.SearchForOneProduct(productId);
                    
                        Console.WriteLine($"The product you are searching for: {productString}");
                        break;
                    }
                    case 5:
                    {
                        var products = await inventoryRepository.GetAllProducts();
                    
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
