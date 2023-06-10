using ApplicationWithCodeFirst.Application.Services;
using MedicalProject.Application.Interfaces;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IAppointmentServices, AppointmentServices>();
            services.AddScoped<IBlogsServices, BlogsServices>();
            services.AddScoped<IBlogTypeServices, BlogTypeServices>();
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddScoped<IDoctorSchedulesServicesServices, DoctorSchedulesServices>();
            services.AddScoped<IContactUsServices,ContactUsServices>();
            services.AddScoped<IDepartmentServices, MedicalProject.Application.Services.DepartmentServices>();
            services.AddScoped<IDepartmentServicesServices, DepartmentServicesServices>();
            services.AddScoped<IServicesServices, ServicesServices>();
            services.AddScoped<IAttachmentServices, AttachmentServices>();

        }
    }
}
