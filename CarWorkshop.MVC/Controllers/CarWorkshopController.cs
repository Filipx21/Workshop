using AutoMapper;
using CarWorkshop.Application.DTO;
using CarWorkshop.Application.Mediator.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mediator.Commands.EditCarWorkshop;
using CarWorkshop.Application.Mediator.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.Mediator.Queries.GetCarWorkshopByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarWorkshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshopsDto = await _mediator.Send(new GetAllCarWorkshopsQuery());

            return View(carWorkshopsDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var carWorkshopDto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(carWorkshopDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
        }

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var carWorkshopDto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            var model = _mapper.Map<EditCarWorkshopCommand>(carWorkshopDto);
            return View(model);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
