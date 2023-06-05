using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
