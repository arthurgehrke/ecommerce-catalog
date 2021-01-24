using System;
using System.Collections.Generic;
using EcommerceCatalog.Repositories;
using EcommerceCatalog.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace EcommerceCatalog.Repositories

{
  public class MongoDbProductsRepository : IProductsRepository
  {
    private const string databaseName = "ecommerce-catalog";
    private const string collectionName = "products";
    private readonly IMongoCollection<Product> productsCollection;
    private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;
    public MongoDbProductsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        productsCollection = database.GetCollection<Product>(collectionName);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
      return await productsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
      var filter = filterBuilder.Eq(product => product.Id, id);
      return await productsCollection.Find(filter).SingleOrDefaultAsync(); 
    }

    public async Task UpdateProductAsync(Product product)
    {
      var filter = filterBuilder.Eq(existingProduct => existingProduct.Id, product.Id);
      await productsCollection.ReplaceOneAsync(filter, product);
    }

    public async Task CreateProductAsync(Product product)
    {
      await productsCollection.InsertOneAsync(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
      var filter = filterBuilder.Eq(existingProduct => existingProduct.Id, id);
      await productsCollection.DeleteOneAsync(filter);
    }
  }
}
