using Grocery.Models;
namespace Grocery.ViewModels.ProductVM
{
    public class ProductSearchViewModel
    {
        public IReadOnlyList<Product> Products { get; set; } = new List<Product>();
        public string? SearchString { get; set; }
        public bool IsActive { get; set; }
    }
}
