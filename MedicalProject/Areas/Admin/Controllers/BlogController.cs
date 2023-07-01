using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly IBlogsServices _blogsServices;
        public readonly  IBlogTypeServices _blogTypeServices;
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;
        public BlogController(IBlogsServices blogsServices, IMapper mapper, IAttachmentServices attachmentServices , IBlogTypeServices blogTypeServices) 
        {

            _blogsServices = blogsServices;
            _attachmentServices = attachmentServices;
            _blogTypeServices= blogTypeServices;
            _mapper= mapper;
        }
        public IActionResult Index()
        {
            var model = _blogsServices.GetAll(a => a.IsDeleted != true).ToList();
            List<BlogVM> Blogs = _mapper.Map<List<BlogVM>>(model);
            return View(Blogs);
        }
        
        public IActionResult Add()
        {
            BlogAddVM blogAddVM = new BlogAddVM()
            {
               BlogTypeId = 0,
               CreationDate = DateTime.Now,
               ImageId = 0,
               extention = "",
                BlogTypeList = new SelectList(_blogTypeServices.GetAll(a => a.IsDeleted != true), "BlogTypeId", "BlogTypeName")

            };
            
            ViewBag.Title = "Add Blog";
            return View(blogAddVM);
        }

        [HttpPost]
        public IActionResult Add(BlogAddVM blogAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Blogs model = _blogsServices.Get(a => a.BlogsId == blogAddVM.BlogsId);
                model = _mapper.Map<Blogs>(blogAddVM);
                _blogsServices.Add(model);
                _blogsServices.Save();

            }
            return Json(1);
        }

        public IActionResult Update(int id)
        {
            BlogAddVM Blog = new BlogAddVM();
            if (id != 0)
            {
                Blogs model = _blogsServices.Get(a => a.BlogsId == id);
                Blog = _mapper.Map<BlogAddVM>(model);
                Blog.extention = model.ImageId == 0 ? "" : _attachmentServices.Get(a => a.AttachmentsId == model.ImageId).Extention;
                Blog.BlogTypeList = new SelectList(_blogTypeServices.GetAll(a => a.IsDeleted != true), "BlogTypeId", "BlogTypeName");
            }

            ViewBag.Title = "Edit Blog";
            return View("Add", Blog);
        }


        [HttpPost]
        public IActionResult Update(BlogAddVM Blog)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Blogs model = _blogsServices.Get(a => a.BlogsId == Blog.BlogsId);
                model = _mapper.Map<Blogs>(Blog);
                _blogsServices.Update(model);
                _blogsServices.Save();

            }
            return Json(1);
        }

        public IActionResult Delete(int id)
        {
            Blogs model = _blogsServices.Get(a => a.BlogsId == id);
            model.IsDeleted = true;
            _blogsServices.Update(model);
            _blogsServices.Save();
            return RedirectToAction("Index");
        }
    }
}
