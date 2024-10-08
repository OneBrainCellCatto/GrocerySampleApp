using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name: "Positions", Schema = "Business")]
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; } = null!;
    }
}
