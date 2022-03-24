using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation.AspNetCore;
using PatientsIS.Application.Features.Patients.Commands.CreatePatient;
using PatientsIS.Application.Features.Patients.Commands.UpdatePatient;

namespace PatientsIS.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
       
            return services;
        }
    }

}
