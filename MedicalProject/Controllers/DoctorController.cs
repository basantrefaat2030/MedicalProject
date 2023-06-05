using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
