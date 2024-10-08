using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync(string? searchString = null, bool isActive = true);
        Task<Product> GetProductAsync(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<bool> SaveChangesAsync();

    }
}
