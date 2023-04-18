using AutoMapper;
using CarWorkshop.Application.DTO.Commands.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.DTO.Commands.Handlers
{
    public class GetAllCarWorkshopQuery : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly ICarWorkshopRepository carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetAllCarWorkshopQuery(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            this.carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await carWorkshopRepository.GetAll();
            var carWorkshopsDto = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return carWorkshopsDto;
        }
    }
}
