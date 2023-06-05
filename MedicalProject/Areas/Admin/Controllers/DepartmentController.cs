using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
