using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name:"Genders",Schema = "Business")]
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
    }
}
