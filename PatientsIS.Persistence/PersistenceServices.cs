using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientsIS.Application.Contracts;
using StudentIS.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsIS.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPatientAsyncRepository), typeof(PatientRepository));

            return services;
        }
    }
}
