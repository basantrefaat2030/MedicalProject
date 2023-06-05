using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
