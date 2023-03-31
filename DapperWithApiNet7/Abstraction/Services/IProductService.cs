using DapperWithApiNet7.Entities;
using System.Security.Principal;

namespace DapperWithApiNet7.Abstraction.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task AddAsyncProduct (Product product);
        Task RemoveAsyncProduct(int productId);
        Task<Product> GetByIdProduct(int productId);
    }
}
