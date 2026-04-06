using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.Services.Implementations;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Interface;
using SchoolManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IStagesService, StagesService>();
            services.AddScoped<ICostCenterService, CostCenterService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IGradesService, GradesService>();
            services.AddScoped<IStudyYearService, StudyYearService>();
            services.AddScoped<IStudentStatusService, StudentStatusService>();
            services.AddScoped<ISupervisorService, SupervisorService>();
            services.AddScoped<ITransCostService, TransCostService>();
            services.AddScoped<ITransferTypeService, TransferTypeService>();
            services.AddScoped<ITransLineService, TransLineService>();
            services.AddScoped<IVatService, VatService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IRegistrationStudentService, RegistrationStudentService>();
            services.AddScoped<PaginationService>();
            return services;
        }
    }
}

