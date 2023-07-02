using ApplicationWithCodeFirst.Application.Services;
using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Numerics;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorServices _doctorServices;
        private readonly IDoctorSchedulesServices _doctorSchedulesServices;
        public readonly  IDepartmentServices _departmentServices;
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorServices doctorServices,IDoctorSchedulesServices doctorSchedulesServices ,IDepartmentServices departmentServices, IAttachmentServices attachmentServices, IMapper mapper)
        {
            _doctorServices = doctorServices;
            _doctorSchedulesServices = doctorSchedulesServices;
            _departmentServices = departmentServices;
            _attachmentServices = attachmentServices;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            var model = _doctorServices.GetAll(a => a.IsDeleted != true, "Department").ToList();
            List<DoctorVM> doctors = _mapper.Map<List<DoctorVM>>(model);
            foreach(var item in doctors)
            {
                foreach(var res in model)
                {
                    item.DepartmentName = res.Department.DepartmentName;
                }
            }
            return View(doctors);
        }

        public IActionResult Add()
        {
            DoctorAddVM doctorAddVM = new DoctorAddVM()
            {
                DoctorId = 0,
                ImageId = 0,
                extention = "",
                Departmentlist = new SelectList(_departmentServices.GetAll(a => a.IsDeleted != true), "DepartmentId", "DepartmentName")

            };

            ViewBag.Title = "Add Doctor";
            return View(doctorAddVM);
        }


        [HttpPost]
        public IActionResult Add(DoctorAddVM doctorvm)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                 Doctor model = _mapper.Map<Doctor>(doctorvm);
                _doctorServices.Add(model);
                _doctorServices.Save();

            }
            return Json(1);
        }

        public IActionResult Update(int id)
        {
            DoctorAddVM doctor = new();
            if (id != 0)
            {
                Doctor model = _doctorServices.Get(a => a.DoctorId == id);
                doctor = _mapper.Map<DoctorAddVM>(model);
                doctor.extention = model.ImageId == 0 ? "" : _attachmentServices.Get(a => a.AttachmentsId == model.ImageId).Extention;
                doctor.Departmentlist = new SelectList(_departmentServices.GetAll(a => a.IsDeleted != true),"DepartmentId", "DepartmentName");
            }

            ViewBag.Title = "Edit Doctor";
            return View("Add", doctor);
        }


        [HttpPost]
        public IActionResult Update(DoctorAddVM doctor)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Doctor model = _doctorServices.Get(a => a.DoctorId == doctor.DoctorId);
                model = _mapper.Map<Doctor>(doctor);
                _doctorServices.Update(model);
                _doctorServices.Save();

            }
            return Json(1);
        }

        public IActionResult Delete(int id)
        {
            Doctor model = _doctorServices.Get(a => a.DoctorId == id , "DoctorSchedules");
            model.IsDeleted = true;
            _doctorServices.Update(model);
            List<DoctorSchedules> doctorSchedules = model.DoctorSchedules.ToList();

            doctorSchedules.ForEach(a => a.IsDeleted = true);
            _doctorServices.Save();

            return RedirectToAction("Index");
        }

        public IActionResult ShowSchedule(int id)
        {
            var model = _doctorSchedulesServices.GetAll(a => a.IsDeleted != true && a.DoctorId == id).ToList();
            DoctorSchedulesVM doctorSchedulesVM = new();
            doctorSchedulesVM.SchedulesList = _mapper.Map<List<ScheduleVm>>(model);
            doctorSchedulesVM.DoctorId = id;
            return View(doctorSchedulesVM);
        }

        public IActionResult AddSchedule(int docId)
        {
            DoctorScheduleAddVM doctorSchedule = new()
            {
                DoctorSchedulesId = 0,
                CreationDate = DateTime.Now,
                DoctorId = docId
            };
             ViewBag.Title = "Add";

            return View(doctorSchedule);

        }
        [HttpPost]
        public IActionResult AddSchedule(DoctorScheduleAddVM doctorSchedule)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                if (_doctorSchedulesServices.CheckByDay(doctorSchedule.DayId ,doctorSchedule.DoctorId) == null)
                {
                    DoctorSchedules model = _mapper.Map<DoctorSchedules>(doctorSchedule);

                    _doctorSchedulesServices.Add(model);
                    _doctorSchedulesServices.Save();
                }else
                    return Json(-1);

            }
            return Json(1);
        }

        public IActionResult UpdateSchedule(int id)
        {
            DoctorScheduleAddVM schedule = new();
            if (id != 0)
            {
                DoctorSchedules model = _doctorSchedulesServices.Get(a => a.DoctorSchedulesId == id);
                schedule = _mapper.Map<DoctorScheduleAddVM>(model);
            }

            ViewBag.Title = "Edit";
            return View("AddSchedule", schedule);
        }
        [HttpPost]
        public IActionResult UpdateSchedule(DoctorScheduleAddVM doctorScheduleAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                DoctorSchedules model = _doctorSchedulesServices.Get(a => a.DoctorSchedulesId == doctorScheduleAddVM.DoctorSchedulesId);
                if (_doctorSchedulesServices.CheckByDay(doctorScheduleAddVM.DayId , doctorScheduleAddVM.DoctorId) == null)
                {

                    model = _mapper.Map<DoctorSchedules>(doctorScheduleAddVM);
                    _doctorSchedulesServices.Update(model);
                    _doctorSchedulesServices.Save();
                }
                else
                    return Json(-1);

            }
            return Json(1);
        }

        public IActionResult ScheduleDelete(int id)
        {
            DoctorSchedules model = _doctorSchedulesServices.Get(a => a.DoctorSchedulesId == id);
            model.IsDeleted = true;
            _doctorSchedulesServices.Update(model);
            _doctorSchedulesServices.Save();

            return RedirectToAction("ShowSchedule", new { id = model.DoctorId });
        }

    }
}
