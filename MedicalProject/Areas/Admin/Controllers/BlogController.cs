using MedicalProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly IBlogsServices _blogsServices;
        public BlogController(IBlogsServices blogsServices) 
        {

            _blogsServices = blogsServices;
        }
        public IActionResult Index()
        {
            var ss = _blogsServices.GetAll();
            return View();
        }
    }
}
