using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(string? searchString = null, bool isActive = true)
        {
            var query = from product in _context.Products
                        select product;
            if(!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ProductName.Contains(searchString));
            }
            if(isActive) 
            {
                query = query.Where(x => x.IsActive == true);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
