using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name: "Suppliers", Schema = "Business")]
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
    }
}
