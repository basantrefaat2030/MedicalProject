using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
