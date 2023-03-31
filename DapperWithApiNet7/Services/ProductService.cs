using Dapper;
using DapperWithApiNet7.Abstraction.Services;
using DapperWithApiNet7.Entities;
using DapperWithApiNet7.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace DapperWithApiNet7.Services
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _context;
        public ProductService(DapperContext context)
        {
            _context = context;
        }
        
        public async Task AddAsyncProduct(Product product)
        {
            var query = "INSERT INTO Product (ProductId, ProductName,ProductPrice,UnitStock) VALUES (@ProductId, @ProductName, @ProductPrice, @UnitStock)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var query = "SELECT * FROM Product";
            using var connection = _context.CreateConnection();
            var products = await connection.QueryAsync<Product>(query);
            return products.ToList();
        }

        public async Task<Product> GetByIdProduct(int productId)
        {
            var query = "SELECT * FROM Product WHERE ProductId = @ProductId";
            using var connection = _context.CreateConnection();
            var product = await connection.QueryFirstAsync<Product>(query, new { ProductId = productId});
            return product;
        }

        public async Task RemoveAsyncProduct(int productId)
        {
            var query = "DELETE FROM Product WHERE ProductId = @productId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new {ProductId = productId }); 
        }
    }
}
