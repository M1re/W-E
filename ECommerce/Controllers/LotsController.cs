using ECommerce.Data;
using ECommerce.Data.Services;
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
    }
}