﻿using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.TenantInfo;
//using RMS.Utility;
namespace RMS.Controllers
{
    public class TenantInfoController : Controller
    {
        private readonly ITenantInfoService _tenantInfoService;

        public TenantInfoController(ITenantInfoService tenantInfoService)
        {
            _tenantInfoService = tenantInfoService;
        }
        public IActionResult Index()
        {
            TenantInfoModel model = new TenantInfoModel();
            model.List = _tenantInfoService.GetList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult GetById(int id)
        {
            var model = _tenantInfoService.GetById(id);
            return Json(model.FloorNumber);
        }

        [HttpPost]
        public IActionResult Create(TenantInfoModel model)
        {
            var model2 = new TenantInfoModel();
            model2 = _tenantInfoService.Create(model);
            model2.List = _tenantInfoService.GetList();
            return View("Index", model2);
        }

        public IActionResult Edit(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = _tenantInfoService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TenantInfoModel model)
        {
            var model1 = _tenantInfoService.Edit(model);
            model.List = _tenantInfoService.GetList();
            return View("Index", model1);
        }


        public IActionResult Delete(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = _tenantInfoService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TenantInfoModel model)
        {
            var model1 = _tenantInfoService.Delete(model);
            model1.List = _tenantInfoService.GetList();
            return View("Index", model1);
        }


    }
}