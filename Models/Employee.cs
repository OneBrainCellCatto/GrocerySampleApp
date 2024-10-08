using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    [Table(name: "Employees", Schema = "Business")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = String.Empty;
        public string LastName { get; set; } = null!;
        [NotMapped]
        public string? FullName => $"{FirstName} {MiddleName} {LastName}";
        public int GenderId { get; set; }
        public Gender Gender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime DateResigned { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public int CivilStatusId { get; set; }
        public CivilStatus CivilStatus { get; set; } = null!;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}
