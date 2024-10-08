using Grocery.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grocery.ViewModels.EmployeeVM
{
    public class EmployeeCRUDVM
    {
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(200), MinLength(2)]
        [RegularExpression(@"^[A-Z][\sa-z]+", ErrorMessage = "Only A-Z letters are available.")]
        public string FirstName { get; set; } = null!;
        [StringLength(100), MinLength(2)]
        [DisplayName("Middle Name")]
        [RegularExpression(@"^[A-Z][\sa-z]+", ErrorMessage = "Only A-Z letters are available.")]
        public string? MiddleName { get; set; } = string.Empty;
        [StringLength(100), MinLength(2)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Z][\sa-z]+", ErrorMessage = "Only A-Z letters are available.")]
        public string LastName { get; set; } = null!;
        public SelectList? Genders { get; set; }
        public int GenderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        [DisplayName("Date Hired")]
        public DateTime DateHired { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        [DisplayName("Date Resigned")]
        public DateTime DateResigned { get; set; } = DateTime.UtcNow;
        [DisplayName("Currently Employed")]
        public bool CurrentlyEmployed { get; set; }
        [DisplayName("Civil Status")]
        public SelectList? CivilStatuses { get; set; }
        [DisplayName("Position")]
        public SelectList? Positions { get; set; }
        public int CivilStatusId { get; set; }
        public int PositionId { get; set; }
    }
}
