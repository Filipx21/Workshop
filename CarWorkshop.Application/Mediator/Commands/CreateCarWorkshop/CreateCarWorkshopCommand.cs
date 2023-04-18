using CarWorkshop.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mediator.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommand : CarWorkshopDto, IRequest {}
}
