using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PatientsIS.Application.Features.Patients.Commands.CreatePatient;
using PatientsIS.Application.Features.Patients.Commands.UpdatePatient;
using System.Reflection;

namespace PatientsIS.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<CreatePatientCommand>, CreatePatientCommandValidator>();
            services.AddTransient<IValidator<UpdatePatientCommand>, UpdatePatientCommandValidator>();

            return services;
        }
    }

}
