using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Common;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using ProductManagement.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public ProductRepository(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);

            return product;
        }

        public async Task<List<Product>> AddRangeAsync(List<Product> products)
        {
            await _dbContext.Products.AddRangeAsync(products);

            return products;
        }

        public Task DeleteProductAsync(Product product)
        {
            _dbContext.Remove(product);

            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(List<Product> products)
        {
            _dbContext.Remove(products);

            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbContext.Products.AsNoTracking().AnyAsync(product => product.Id == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllBySearchParamsAsync(SearchParams searchParams)
        {
            return await _dbContext.Products
            .Where(product => product.UserId == searchParams.UserId)
            .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public void UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
        }

        public void UpdateRangeAsync(List<Product> products)
        {
            _dbContext.Products.UpdateRange(products);
        }
    }
}
