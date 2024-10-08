using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Grocery.ViewModels.EmployeeVM
{
    public class EmployeeSearchViewModel
    {
        public IReadOnlyList<EmployeeReadVM> Employees { get; set; } = new List<EmployeeReadVM>();
        public SelectList? CivilStatuses { get; set; }
        public SelectList? Positions { get; set; }
        public string? CivilStatusFilter { get; set; }
        public string? PositionFilter { get; set; }
        public string? SearchString { get; set; }
        [DisplayName("Currently Employed")]
        public bool CurrentlyEmployed { get; set; }

    }
}
