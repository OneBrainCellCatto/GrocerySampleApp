using Grocery.Models;
using Grocery.Services.Interfaces;
using Grocery.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Grocery.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICivilStatusRepository _civilStatusRepo;
        private readonly IPositionRepository _positionRepo;
        private readonly IGenderRepository _genderRepo;
        public EmployeeController(IEmployeeRepository employeeRepo, 
                ICivilStatusRepository civilStatusRepo, 
                IPositionRepository positionRepo,
                IGenderRepository genderRepo
                )
        {
            _employeeRepo = employeeRepo;
            _civilStatusRepo = civilStatusRepo;
            _positionRepo = positionRepo;
            _genderRepo = genderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? civilStatusFilter, int? positionFilter, string? searchString, bool CurrentlyEmployed)
        {
            var employees = await _employeeRepo
                .GetEmployees(civilStatusFilter, positionFilter, searchString, CurrentlyEmployed);
            var employeesToViewModel = employees.Select(x => new EmployeeReadVM
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Gender = x.Gender,
                BirthDate = x.BirthDate,
                DateHired = x.DateHired,
                DateResigned = x.DateResigned,
                CurrentlyEmployed = x.CurrentlyEmployed,
                CivilStatus = x.CivilStatus,
                Position = x.Position
            }).ToList();
            var viewModel = new EmployeeSearchViewModel
            {
                Employees = employeesToViewModel,
                CivilStatuses = new SelectList(await _civilStatusRepo.GetCivilStatuses(), "CivilStatusId", "CivilStatusName"),
                Positions = new SelectList(await _positionRepo.GetPositions(),"PositionId","PositionName"),
                CurrentlyEmployed = CurrentlyEmployed
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _employeeRepo.GetEmployee(id.Value);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new EmployeeCRUDVM
            {
                Genders = new SelectList(await _genderRepo.GetGenders(),"GenderId","GenderName"),
                CivilStatuses = new SelectList(await _civilStatusRepo.GetCivilStatuses(),"CivilStatusId","CivilStatusName"),
                Positions = new SelectList(await _positionRepo.GetPositions(),"PositionId","PositionName")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCRUDVM EmployeeCRUDVM)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    EmployeeId = EmployeeCRUDVM.EmployeeId,
                    FirstName = EmployeeCRUDVM.FirstName,
                    LastName = EmployeeCRUDVM.LastName,
                    MiddleName = EmployeeCRUDVM.MiddleName,
                    GenderId = EmployeeCRUDVM.GenderId,
                    BirthDate = EmployeeCRUDVM.BirthDate,
                    DateHired = EmployeeCRUDVM.DateHired,
                    DateResigned = EmployeeCRUDVM.DateResigned,
                    CurrentlyEmployed = EmployeeCRUDVM.CurrentlyEmployed,
                    CivilStatusId = EmployeeCRUDVM.CivilStatusId,
                    PositionId = EmployeeCRUDVM.PositionId,
                };
                _employeeRepo.AddEmployee(employee);
                await _employeeRepo.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Create),EmployeeCRUDVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = await _employeeRepo.GetEmployee(id.Value);

            if (employee is null)
                return NotFound();

            var viewModel = new EmployeeCRUDVM
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                GenderId = employee.GenderId,
                PositionId= employee.PositionId,
                CivilStatusId = employee.CivilStatusId,
                BirthDate = employee.BirthDate,
                DateHired = employee.DateHired,
                DateResigned = employee.DateResigned,
                CurrentlyEmployed = employee.CurrentlyEmployed,
                Genders = new SelectList(await _genderRepo.GetGenders(),"GenderId","GenderName", employee.GenderId),
                CivilStatuses = new SelectList(await _civilStatusRepo.GetCivilStatuses(), "CivilStatusId", "CivilStatusName", employee.CivilStatusId),
                Positions = new SelectList(await _positionRepo.GetPositions(), "PositionId", "PositionName", employee.PositionId),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, EmployeeCRUDVM viewModel)
        {
            if (id != viewModel.EmployeeId)
                return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    var employee = new Employee
                    {
                        EmployeeId = viewModel.EmployeeId,
                        FirstName = viewModel.FirstName,
                        MiddleName = viewModel.MiddleName,
                        LastName = viewModel.LastName,
                        GenderId = viewModel.GenderId,
                        BirthDate = viewModel.BirthDate,
                        DateHired = viewModel.DateHired,
                        DateResigned = viewModel.DateResigned,
                        CurrentlyEmployed = viewModel.CurrentlyEmployed,
                        CivilStatusId = viewModel.CivilStatusId,
                        PositionId = viewModel.PositionId,
                    };
                    _employeeRepo.UpdateEmployee(employee);
                    await _employeeRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(await _employeeRepo.GetEmployee(id) is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var employeeToDelete = await _employeeRepo.GetEmployee(id);
            if(employeeToDelete is null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute]int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return NotFound();

            _employeeRepo.DeleteEmployee(employee);
            await _employeeRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
