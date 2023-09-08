using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.BL.DataService
{
    public class DataAccess
    {
        private readonly IMongoCollection<BsonDocument> _productDocuments;

        public DataAccess(IMongoCollection<BsonDocument> productDocuments)
        {
            _productDocuments = productDocuments;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var productDocuments = await _productDocuments.FindAsync(new BsonDocument());
            var productDocsList = productDocuments.ToList();

            return productDocsList.Select(product => new Product()
            {
                Id = product["_id"].AsObjectId,
                Name = product["name"].AsString,
                Price = product["price"].ToDecimal(),
                Quantity = product["quantity"].ToInt32(),
            }).ToList();
        }

        public async Task<Product> GetOneProduct(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            var studentDocs = await _productDocuments.FindAsync(filter);
            var studentDocument = studentDocs.FirstOrDefault();
            
            return new Product()
            {
                Id = studentDocument["_id"].AsObjectId,
                Name = studentDocument["name"].AsString,
                Price = studentDocument["price"].ToDecimal(),
                Quantity = studentDocument["quantity"].ToInt32(),
            };
        }

        public async Task<bool> InsetProduct(ProductData product)
        {
            try
            {
                var productDocument = new BsonDocument()
                {
                    { "name", product.Name },
                    { "price", product.Price },
                    { "quantity", product.Quantity },
                };

                await _productDocuments.InsertOneAsync(productDocument);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(string id, ProductData productData)
        {
            try
            {
                var newProduct = new BsonDocument()
                {
                    { "name", productData.Name },
                    { "price", productData.Price },
                    { "quantity", productData.Quantity },
                };

                var replaceResult = await _productDocuments.ReplaceOneAsync(
                    doc => doc["_id"] == new ObjectId(id),
                    newProduct);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(string id)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

                await _productDocuments.DeleteOneAsync(filter);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}