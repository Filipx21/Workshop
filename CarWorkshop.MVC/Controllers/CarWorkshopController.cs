using CarWorkshop.Application.DTO;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService carWorkshopService;
        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            this.carWorkshopService = carWorkshopService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            if (!ModelState.IsValid)
            {
                return View(carWorkshop);
            }
            await carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create)); // todo
        }
    }
}
