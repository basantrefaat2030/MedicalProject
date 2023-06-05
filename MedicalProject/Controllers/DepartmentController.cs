using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }
    }
}
