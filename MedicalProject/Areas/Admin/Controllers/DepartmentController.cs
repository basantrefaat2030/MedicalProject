using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.infrastructure.ViewModel;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentServices departmentServices,IMapper mapper)
            {
            _departmentServices= departmentServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _departmentServices.GetAll(a => a.IsDeleted != true).ToList();
            List<DepartmentVM> Departments = _mapper.Map<List<DepartmentVM>>(model);
            return View(Departments);
        }

        public IActionResult Add() 
        {
            DepartmentAddVM departmentAddVM = new() { CreationDate = DateTime.Now, ImageId = 0, extention = "" };
            return View(departmentAddVM);
        }

        [HttpPost]
        public IActionResult Add(DepartmentAddVM departmentAddVM)
        {

            return View();
        }



    }
}
