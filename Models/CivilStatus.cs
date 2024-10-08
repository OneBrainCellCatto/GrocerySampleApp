using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name: "CivilStatuses", Schema = "Business")]
    public class CivilStatus
    {
        public int CivilStatusId { get; set; }
        public string CivilStatusName { get; set; } = null!;

    }
}
