﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganisationArchive.DAL.Migrations;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace OrganisationArchive.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employee;
        private IPersonService _personService;

        public EmployeeController(IEmployeeService employee, IPersonService personService)
        {
            _employee = employee;
            _personService = personService;
        }
        // GET: EmployeeController
        public ActionResult Employees()
        {
            var employees = _employee.getEmployee();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employees = _employee.GetEmployeenById(id);
            return View(employees);
        }

        // GET: EmployeeController/Create
        public ActionResult Create(DAL.Models.Organization organization)
        {
            var person = _personService.getPeople();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employee.AddEmployee(employee);
                return RedirectToAction(nameof(employee));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
