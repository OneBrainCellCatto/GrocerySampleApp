using Grocery.Models;
using Grocery.Services.Interfaces;
using Grocery.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? searchString, bool isActive)
        {
            var viewModel = new ProductSearchViewModel
            {
                Products = await _productRepo.GetProductsAsync(searchString, isActive),
                SearchString = searchString,
                IsActive = isActive
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _productRepo.AddProduct(product);
                await _productRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _productRepo.GetProductAsync(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id, Product product)
        {
            if(id != product.ProductId)
                return NotFound();

            if (id == null)
                return NotFound();

            _productRepo.DeleteProduct(product);
            await _productRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _productRepo.GetProductAsync(id.Value);

            if(product == null)
                return NotFound();

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _productRepo.GetProductAsync(id.Value);

            if(product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            _productRepo.UpdateProduct(product);
            await _productRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
