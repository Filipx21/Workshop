using CarWorkshop.Application.Mappings;
using CarWorkshop.Application.Services;
using CarWorkshop.Application.Validators;
using FluentValidation.AspNetCore;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarWorkshopService, CarWorkshopService>();

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CarWorkshopDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
