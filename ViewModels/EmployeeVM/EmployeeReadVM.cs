using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Grocery.Models;

namespace Grocery.ViewModels.EmployeeVM
{
    public class EmployeeReadVM
    {
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; } = null!;
        public bool CurrentlyEmployed { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Hired")]
        public DateTime DateHired { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Resigned")]
        public DateTime DateResigned { get; set; }
        [DisplayName("Civil Status")]
        public CivilStatus CivilStatus { get; set; } = null!;
        public Position Position { get; set; } = null!;

    }
}
