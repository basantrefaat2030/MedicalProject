using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.infrastructure.ViewModel;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryServices categoryServices, IMapper mapper) 
        {
            _categoryServices = categoryServices;
            _mapper = mapper;

        } 
        public IActionResult Index()
        {
            var model = _categoryServices.GetAll(a => a.IsDeleted != true).ToList();
            List<CategoryVM> categoryVM = _mapper.Map<List<CategoryVM>>(model);
            return View(categoryVM);
        }

        public IActionResult Add()
        {
            CategoryAddVM categoryVM = new()
            {
                CreationDate= DateTime.Now,
                CategoryId = 0
            };
            ViewBag.Title = "Add New Category";
            return View(categoryVM);
        }

        [HttpPost]
        public IActionResult Add(CategoryAddVM categoryAdd)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Category model = _mapper.Map<Category>(categoryAdd);
                _categoryServices.Add(model);
                _categoryServices.Save();
            }

            return Json(1);
           
        }


        public IActionResult Update(int id)
        {
            CategoryAddVM categoryAddVM = new CategoryAddVM();
            if (id != 0)
            {
                Category model = _categoryServices.Get(a => a.CategoryId == id);
                categoryAddVM = _mapper.Map<CategoryAddVM>(model);
            }

            ViewBag.Title = "Edit Category";
            return View("Add", categoryAddVM);
        }

        [HttpPost]
        public IActionResult Update(CategoryAddVM categoryAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {

                Category model = _categoryServices.Get(a => a.CategoryId == categoryAddVM.CategoryId);
                model = _mapper.Map<Category>(model);
                _categoryServices.Update(model);
                _categoryServices.Save();

            }
            return Json(1);
        }


        public IActionResult Delete(int id)
        {
            Category model = _categoryServices.Get(a => a.CategoryId == id);
            model.IsDeleted = true;
            _categoryServices.Update(model);
            _categoryServices.Save();
            return RedirectToAction("Index");
        }

    }
}
