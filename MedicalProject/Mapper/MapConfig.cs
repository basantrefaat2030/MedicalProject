using AutoMapper;
using MedicalProject.infrastructure.ViewModel;
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

        }
    }
}
