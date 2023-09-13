using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.BL.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.BL.Repositories
{
    public class MongoInventoryService : IInventoryService
    {
        private readonly IMongoCollection<BsonDocument> _productsCollection;

        public MongoInventoryService(IMongoCollection<BsonDocument> productsCollection)
        {
            _productsCollection = productsCollection;
        }

        public async Task AddNewProduct(Product product)
        {
            var productDocument = new BsonDocument()
            {
                { "name", product.Name },
                { "price", product.Price },
                { "quantity", product.Quantity },
            };

            await _productsCollection.InsertOneAsync(productDocument);
        }

        public async Task EditProduct(Product product)
        {
            var newProduct = new BsonDocument()
            {
                { "name", product.Name },
                { "price", product.Price },
                { "quantity", product.Quantity },
            };

            var replaceResult = await _productsCollection.ReplaceOneAsync(
                doc => doc["_id"] == new ObjectId(product.Id),
                newProduct);
        }

        public async Task RemoveProduct(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            await _productsCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var productDocuments = await _productsCollection.FindAsync(new BsonDocument());
            var productDocsList = productDocuments.ToList();

            return productDocsList.Select(product => new Product()
            {
                Id = product["_id"].ToString(),
                Name = product["name"].ToString(),
                Price = product["price"].ToDecimal(),
                Quantity = product["quantity"].ToInt32(),
            }).ToList();
        }

        public async Task<Product> GetOneProduct(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            var studentDocs = await _productsCollection.FindAsync(filter);
            var studentDocument = studentDocs.FirstOrDefault();
            
            return new Product()
            {
                Id = studentDocument["_id"].ToString(),
                Name = studentDocument["name"].ToString(),
                Price = studentDocument["price"].ToDecimal(),
                Quantity = studentDocument["quantity"].ToInt32(),
            };
        }
    }
}