// Data/Repositories/IProductRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestApi.Models;

namespace MyRestApi.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
