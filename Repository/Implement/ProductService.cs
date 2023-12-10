﻿using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            return productRepository.CreateProductAsync(product);

        }
        public Task<bool> DeleteProductAsync(int productId)
        {
            return productRepository.DeleteProductAsync(productId);
        }

        public Product GetProduct(int productId)
        {
            return productRepository.GetProduct(productId);
        }

        public async Task<Product> GetProductAndOwnerAsync(int productId)
        {
            return await productRepository.GetProductAndOwnerAsync(productId);
        }

        public Task<Product> GetProductAsync(int productId)
        {
            return productRepository.GetProductAsync(productId);
        }

        public List<Product> GetProducts(int noOfProducts = 100)
        {
            return productRepository.GetProducts(noOfProducts);
        }

        public Task<List<Product>> GetProductsAsync(int noOfProducts = 100)
        {
            return productRepository.GetProductsAsync(noOfProducts);
        }

        public async Task<bool> IsProductExistAsync(string name, int id)
        {
            var product = await productRepository.GetProductByNameAsync(name, id);
            return product != null;
        }

        public async Task<bool> IsProductNameExistAsync(string name)
        {
            var product = await productRepository.GetProductByNameAsync(name);
            return product != null;
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            return productRepository.UpdateProductAsync(product);
        }
    }
}
