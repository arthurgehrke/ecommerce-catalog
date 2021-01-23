using System;
using System.Collections.Generic;
using EcommerceCatalog.Repositories;
using EcommerceCatalog.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

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

    public IEnumerable<Product> GetProducts()
    {
      return productsCollection.Find(new BsonDocument()).ToList();
    }

    public Product GetProduct(Guid id)
    {
      var filter = filterBuilder.Eq(product => product.Id, id);

      return productsCollection.Find(filter).SingleOrDefault(); 
    }

    public void UpdateProduct(Product product)
    {
      var filter = filterBuilder.Eq(existingProduct => existingProduct.Id, product.Id);
      productsCollection.ReplaceOne(filter, product);
    }

    public void CreateProduct(Product product)
    {
      productsCollection.InsertOne(product);
    }

    public void DeleteProduct(Guid id)
    {
      var filter = filterBuilder.Eq(existingProduct => existingProduct.Id, id);
      productsCollection.DeleteOne(filter);
    }
  }
}
