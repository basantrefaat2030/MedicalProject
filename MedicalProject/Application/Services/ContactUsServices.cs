using ApplicationWithCodeFirst.Application.Services;
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class ContactUsServices : RepositoryBase<ContactUs>, IContactUsServices
    {
        public ContactUsServices(ApplicationDbContext db) : base(db)
        {
        }
    }


    public interface IContactUsServices : IRepository<ContactUs>
    {

    }
}
