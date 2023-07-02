using ApplicationWithCodeFirst.Application.Services;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IDoctorServices _doctorServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly IProductServices _productServices;
        public HomeController(ICategoryServices categoryServices,IDoctorServices doctorServices,IDepartmentServices departmentServices ,IProductServices productServices)
        {
            _categoryServices= categoryServices;
            _doctorServices= doctorServices;
            _departmentServices= departmentServices;
            _productServices = productServices;
        }
        public IActionResult Index()
        {
            HomeVM model = new()
            {
                CategoryCount = _categoryServices.CategoryCount(),
                DepartmentCount= _departmentServices.DepartmentCount(),
                DoctorCount= _doctorServices.DoctorCount(),
                ProductCount = _productServices.ProductCount(),

            };
            return View(model);
        }
    }
}
