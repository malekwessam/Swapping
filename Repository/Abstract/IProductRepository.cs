using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IProductRepository
    {
        Product GetProduct(int productId);
        List<Product> GetProducts(int noOfProducts);

        Task<Product> GetProductAsync(int productId);
        Task<List<Product>> GetProductsAsync(int noOfProducts);

        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
        Task<Product> GetProductByNameAsync(string name);
        Task<Product> GetProductByNameAsync(string name, int id);
        Task<Product>GetProductAndOwnerAsync(int productId);

    }
}
