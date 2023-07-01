using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ServicesController : Controller
    {
        private readonly IServicesServices _servicesServices;
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;
        public ServicesController(IServicesServices servicesServices, IMapper mapper , IAttachmentServices attachmentServices) 
        {
            _servicesServices = servicesServices;
            _mapper = mapper;
            _attachmentServices = attachmentServices;
        }
        public IActionResult Index()
        {
            var model = _servicesServices.GetAll(a => a.IsDeleted != true).ToList();
            List<ServicesVM> List  = _mapper.Map<List<ServicesVM>>(model);
            return View(List);
        }
       
        public IActionResult Add()
        {
            ServicesAddVM servicesAddVM = new()
            {
                CreationDate = DateTime.Now,
                ServicesId = 0,
                ImageId = 0,
                extention = ""
            };
            ViewBag.Title = "Add New Service";
            return View(servicesAddVM);
        }
        [HttpPost]
        public IActionResult Add(ServicesAddVM servicesAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Services model = _mapper.Map<Services>(servicesAddVM);
                _servicesServices.Add(model);
                _servicesServices.Save();
            }

            return Json(1);
        }
        public IActionResult Update(int id)
        {
            ServicesAddVM servicesAddVM = new ServicesAddVM();
            if (id != 0)
            {
                Services model = _servicesServices.Get(a => a.ServicesId == id);
                servicesAddVM = _mapper.Map<ServicesAddVM>(model);
                servicesAddVM.extention = model.ImageId == 0 ? "" : _attachmentServices.Get(a => a.AttachmentsId == model.ImageId).Extention;
            }

            ViewBag.Title = "Edit Service";
            return View("Add", servicesAddVM);
        }
        [HttpPost]
        public IActionResult Update(ServicesAddVM servicesAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {

                Services model = _servicesServices.Get(a => a.ServicesId == servicesAddVM.ServicesId);
                model = _mapper.Map<Services>(servicesAddVM);
                _servicesServices.Update(model);
                _servicesServices.Save();

            }
            return Json(1);
        }


        public IActionResult Delete(int id)
        {
            Services model = _servicesServices.Get(a => a.ServicesId == id);
            model.IsDeleted = true;
            _servicesServices.Update(model);
            _servicesServices.Save();
            return RedirectToAction("Index");
        }

    }
}
