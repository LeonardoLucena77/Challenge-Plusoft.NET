using PlusoftRecommender.Models;
using PlusoftRecommender.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlusoftRecommender.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Delegar a chamada para o repositório
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            // Delegar a chamada para o repositório
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            // Adicionar o produto usando o repositório
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Atualizar o produto usando o repositório
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            // Remover o produto usando o repositório
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
