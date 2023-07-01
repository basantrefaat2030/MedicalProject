using ApplicationWithCodeFirst.Application.Services;
using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.ViewModel;
using MedicalProject.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _ProductServices;
        public readonly ICategoryServices _CategoryServices;
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;
        public ProductController(IProductServices ProductServices , ICategoryServices CategoryServices, IAttachmentServices attachmentServices , IMapper mapper) { 
            _ProductServices= ProductServices;
            _CategoryServices= CategoryServices;
            _attachmentServices = attachmentServices;
            _mapper = mapper;
        
        }
        public IActionResult Index()
        {
            var model = _ProductServices.GetAll(a => a.IsDeleted != true ,"Category").ToList();
            List<ProductVM> products = _mapper.Map<List<ProductVM>>(model);
            foreach(var product in products)
            {

                foreach (var item in model)
                {
                    product.CategoryName = item.Category.CategoryName;
                }

            }
            
            return View(products);
        }
        public IActionResult Add()
        {
            ProductAddVM productAddVM = new ProductAddVM()
            {
                ProductId =0,
                ImageId=0,
                extention = "",
                CategoryList = new SelectList(_CategoryServices.GetAll(a => a.IsDeleted != true), "CategoryId", "CategoryName")

            };

            ViewBag.Title = "Add Product";
            return View(productAddVM);
        }


        [HttpPost]
        public IActionResult Add(ProductAddVM productvm)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Product model = _ProductServices.Get(a => a.ProductId == productvm.ProductId);
                model = _mapper.Map<Product>(productvm);
                _ProductServices.Add(model);
                _ProductServices.Save();

            }
            return Json(1);
        }

        public IActionResult Update(int id)
        {
            ProductAddVM product = new ();
            if (id != 0)
            {
                Product model = _ProductServices.Get(a => a.ProductId == id);
                product = _mapper.Map<ProductAddVM>(model);
                product.extention = model.ImageId == 0 ? "" : _attachmentServices.Get(a => a.AttachmentsId == model.ImageId).Extention;
                product.CategoryList = new SelectList(_CategoryServices.GetAll(a => a.IsDeleted != true), "CategoryId", "CategoryName");
            }

            ViewBag.Title = "Edit Product";
            return View("Add", product);
        }


        [HttpPost]
        public IActionResult Update(ProductAddVM product)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Product model = _ProductServices.Get(a => a.ProductId == product.ProductId);
                model = _mapper.Map<Product>(product);
                _ProductServices.Update(model);
                _ProductServices.Save();

            }
            return Json(1);
        }

        public IActionResult Delete(int id)
        {
            Product model = _ProductServices.Get(a => a.ProductId == id);
            model.IsDeleted = true;
            _ProductServices.Update(model);
            _ProductServices.Save();
            return RedirectToAction("Index");
        }
    }
}
