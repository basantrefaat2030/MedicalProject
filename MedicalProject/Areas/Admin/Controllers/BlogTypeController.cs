using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogTypeController : Controller
    {
        private readonly IBlogTypeServices _blogTypeServices;
        private readonly IMapper _mapper;

        public BlogTypeController(IBlogTypeServices blogTypeServices , IMapper map)
        {
            _blogTypeServices= blogTypeServices;
            _mapper = map;
        }
        public IActionResult Index()
        {
            var model = _blogTypeServices.GetAll();
            List<BlogTypeVM>  BlogTypes = _mapper.Map<List<BlogTypeVM>>(model);
            return View(BlogTypes);
        }

        public IActionResult Add()
        {
            BlogTypeAdd blog = new BlogTypeAdd
            {
                CreationDate = DateTime.Now,
            };

            ViewBag.Title = "Add New Blog Type";
            return View(blog);
        }

        [HttpPost]
        public IActionResult Add(BlogTypeAdd blog)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                BlogType model = _mapper.Map<BlogType>(blog);
                _blogTypeServices.Add(model);
                _blogTypeServices.Save();
            }

            return Json(1);

        }
        public IActionResult Update(int id)
        {
            BlogTypeAdd blogtypeVm = new BlogTypeAdd();
            if (id != 0)
            {
                BlogType model = _blogTypeServices.Get(a => a.BlogTypeId == id);
                blogtypeVm = _mapper.Map<BlogTypeAdd>(model);
            }
            
            ViewBag.Title = "Edit Blog Type";
            return View("Add", blogtypeVm);
        }

        [HttpPost]
        public IActionResult Update(BlogTypeAdd blogType , int id)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {

                BlogType model = _blogTypeServices.Get(a => a.BlogTypeId == id);
                model = _mapper.Map<BlogType>(blogType);
                _blogTypeServices.Update(model);
                _blogTypeServices.Save();

            }
            return Json(1);
        }

        public IActionResult Delete(int id) 
        {
            BlogType model = _blogTypeServices.Get(a =>a.BlogTypeId == id);
            model.IsDeleted = true;
            _blogTypeServices.Update(model);
            _blogTypeServices.Save();
            return RedirectToAction("Index");
        }

    }
}
