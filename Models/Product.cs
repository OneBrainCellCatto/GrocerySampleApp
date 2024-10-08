using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name: "Products", Schema = "Business")]
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int InStock { get; set; }
        public decimal SRP { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
