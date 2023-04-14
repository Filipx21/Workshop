using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {

        private readonly ICarWorkshopRepository carWorkshopRepository;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
        {
            this.carWorkshopRepository = carWorkshopRepository;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            await carWorkshopRepository.Create(carWorkshop);
        }
    }
}
