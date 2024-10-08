using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;

namespace Grocery.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _supplierRepo;

        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepo = supplierRepository;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            return View(await _supplierRepo.GetSuppliersAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetSupplierAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,CompanyName,CompanyEmail")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierRepo.AddSupplier(supplier);
                await _supplierRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetSupplierAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,CompanyName,CompanyEmail")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _supplierRepo.UpdateSupplier(supplier);
                    await _supplierRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_supplierRepo.GetSupplierAsync(id) is null)
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
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetSupplierAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Supplier supplier)
        {
            if (id != supplier.SupplierId)
                return NotFound();

            _supplierRepo.DeleteSupplier(supplier);
            await _supplierRepo.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

    }
}
