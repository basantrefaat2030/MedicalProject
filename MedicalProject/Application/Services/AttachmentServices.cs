using MedicalProject.Infrastructure.Entities;
using MedicalProject.Application.Interfaces;

namespace MedicalProject.Application.Services
{
    public class AttachmentServices : RepositoryBase<Attachments>, IAttachmentServices
    {
        public AttachmentServices(ApplicationDbContext db) : base(db)
        {
        }
    }


    public interface IAttachmentServices : IRepository<Attachments>
    {
       

    }
}

