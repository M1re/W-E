using ECommerce.Data.Cart;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class LotsController : Controller
    {
        private readonly ILotsService _service;

        public LotsController(ILotsService service)
        {
            _service= service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }
        
        public async Task<IActionResult> Filter(string searchString)
        {
            var allLots = await _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allLots.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allLots);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Picture,Name,Type,Description,DealType")]Lot lot)
        {
            if (!ModelState.IsValid)
            {
                return View(lot);
            }
            await _service.Add(lot);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var lotDetails = await _service.GetById(id);

            if (lotDetails == null) return View("NotFound");
            return View(lotDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lotDetails = await _service.GetById(id);
            if (lotDetails == null) return View("NotFound");
            return View(lotDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Picture,Name,Type,Description,DealType")] Lot lot)
        {
            if (!ModelState.IsValid)
            {
                return View(lot);
            }
            await _service.Update(lot, id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lotDetails = await _service.GetById(id);
            if (lotDetails == null) return View("NotFound");
            return View(lotDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lotDetails = await _service.GetById(id);
            if (lotDetails == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}