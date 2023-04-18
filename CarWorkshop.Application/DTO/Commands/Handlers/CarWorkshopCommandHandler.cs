using AutoMapper;
using CarWorkshop.Application.DTO.Commands.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.DTO.Commands.Handlers
{
    public class CarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            this.carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

            carWorkshop.EncodeName();
            await carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
