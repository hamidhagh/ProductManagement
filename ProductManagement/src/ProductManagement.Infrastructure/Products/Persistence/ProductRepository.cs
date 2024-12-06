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

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> AddRangeAsync(List<Product> products)
        {
            await _dbContext.Products.AddRangeAsync(products);

            await _dbContext.SaveChangesAsync();

            return products;
        }

        public async Task DeleteProductAsync(Product product)
        {
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            _dbContext.Remove(productToDelete);

            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(List<Product> products)
        {
            _dbContext.Remove(products);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().AnyAsync(product => product.Id == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllBySearchParamsAsync(Guid? id)
        {
            return await _dbContext.Products
            .Where(product => product.UserId == id)
            .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<Product> GetByIdNoTrackingAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateRangeAsync(List<Product> products)
        {
            _dbContext.Products.UpdateRange(products);

            await _dbContext.SaveChangesAsync();

        }
    }
}
