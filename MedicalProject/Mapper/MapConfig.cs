using AutoMapper;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;

namespace MedicalProject.Mapper
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
           this.CreateMap<BlogTypeVM, BlogType>();
           this.CreateMap<BlogType, BlogTypeVM>();
           this.CreateMap<BlogTypeAdd, BlogType>().ReverseMap();

        }
    }
}
