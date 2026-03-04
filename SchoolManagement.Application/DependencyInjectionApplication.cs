using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Infrastructure.Interface;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Infrastructure;
namespace SchoolManagement.Application
{

    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITransferTypeService, TransferTypeService>();
            services.AddScoped<INationService, NationService>();
            services.AddScoped<IDriveService, DriveService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IDiscountService, DiscountService>();

            return services;
        }
    }
}

