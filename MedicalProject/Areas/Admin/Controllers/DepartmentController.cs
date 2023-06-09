﻿using AutoMapper;
using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentServices departmentServices, IMapper mapper , IAttachmentServices attachmentServices)
        {
            _departmentServices = departmentServices;
            _attachmentServices = attachmentServices;
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
            DepartmentAddVM departmentAddVM = new() { DepartmentId = 0 , CreationDate = DateTime.Now, ImageId = 0, extention = "" };
            ViewBag.Title = "Add Department";
            return View(departmentAddVM);
        }

        [HttpPost]
        public IActionResult Add(DepartmentAddVM departmentAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Department model = _mapper.Map<Department>(departmentAddVM);
                _departmentServices.Add(model);
                _departmentServices.Save();
            }
            return Json(1);
           
        }

        public IActionResult Update(int id)
        {
            DepartmentAddVM departmentAddVM = new DepartmentAddVM();
            if (id != 0)
            {
                Department model = _departmentServices.Get(a => a.DepartmentId == id);
                departmentAddVM = _mapper.Map<DepartmentAddVM>(model);
                departmentAddVM.extention = model.ImageId == 0 ? "" : _attachmentServices.Get(a => a.AttachmentsId == model.ImageId).Extention;
            }

            ViewBag.Title = "Edit Department";
            return View("Add", departmentAddVM);
        }

        
        [HttpPost]
        public IActionResult Update(DepartmentAddVM departmentAddVM)
        {
            if (!ModelState.IsValid)
                return Json(2);
            else
            {
                Department model = _departmentServices.Get(a => a.DepartmentId == departmentAddVM.DepartmentId);
                model = _mapper.Map<Department>(departmentAddVM);
                _departmentServices.Update(model);
                _departmentServices.Save();

            }
            return Json(1);
        }

        public IActionResult Delete(int id)
        {
            Department model = _departmentServices.Get(a => a.DepartmentId == id);
            model.IsDeleted = true;
            _departmentServices.Update(model);
            _departmentServices.Save();
            return RedirectToAction("Index");
        }

    }
}
