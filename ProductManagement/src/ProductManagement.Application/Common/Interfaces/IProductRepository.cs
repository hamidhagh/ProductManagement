using ProductManagement.Application.Common;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        void UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllBySearchParamsAsync(SearchParams searchParams);
        Task<List<Product>> AddRangeAsync(List<Product> products);
        void UpdateRangeAsync(List<Product> products);
        Task DeleteRangeAsync(List<Product> products);
        Task<bool> ExistsAsync(Guid id);
    }
}
