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

        public async Task<IActionResult> Index()
        {
            var carWorkshopsDto = await carWorkshopService.GetAll();

            return View(carWorkshopsDto);
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
            return RedirectToAction(nameof(Index)); 
        }
    }
}
