using AutoMapper;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;

namespace MedicalProject.Mapper
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
           //blogtype
           this.CreateMap<BlogTypeVM, BlogType>();
           this.CreateMap<BlogType, BlogTypeVM>();
           this.CreateMap<BlogTypeAdd, BlogType>().ReverseMap();

           //departmenr
           this.CreateMap<DepartmentVM, Department>().ReverseMap();
           this.CreateMap<DepartmentAddVM, Department>().ReverseMap();

            //Category
            this.CreateMap<CategoryVM, Category>().ReverseMap();
            this.CreateMap<CategoryAddVM, Category>().ReverseMap();

            //Services
            this.CreateMap<ServicesVM, Services>().ReverseMap();
            this.CreateMap<ServicesAddVM, Services>().ReverseMap();

            //Blog
            this.CreateMap<BlogVM, Blogs>().ReverseMap();
            this.CreateMap<BlogAddVM, Blogs>().ReverseMap();
            //product 
            this.CreateMap<ProductVM, Product>().ReverseMap();
            this.CreateMap<ProductAddVM, Product>().ReverseMap();
            //doctor
            this.CreateMap<DoctorVM, Doctor>().ReverseMap();
            this.CreateMap<DoctorAddVM, Doctor>().ReverseMap();

            //doctor schedule
            this.CreateMap<DoctorSchedulesVM, DoctorSchedules>().ReverseMap();


        }
    }
}
