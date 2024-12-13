// Services/IProductService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestApi.Models;
using MyRestApi.Models.DTOs;

namespace MyRestApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductCreateDto productDto);
        Task<Product> UpdateProductAsync(int id, ProductUpdateDto productDto);
        Task DeleteProductAsync(int id);
    }
}