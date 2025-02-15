﻿using EmployeeCRUD.DAL;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Employee_DAL _dal;
        public EmployeeController(Employee_DAL dal)
        {
            _dal = dal;
        }
        [HttpGet]



        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _dal.GetAll();
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
            }

            return View(employees);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (!ModelState.IsValid) 
            {
                TempData["errorMessage"] = "Model data is invalid.";
            }
            bool result = _dal.Insert(model);
            if(!result)
            {
                TempData["errorMessage"] = "Enable to save the data";
                return View();
            }
            TempData["SucessMessage"] = "Employee Created Successfully";
            return RedirectToAction("Index");
        }
    }
}
