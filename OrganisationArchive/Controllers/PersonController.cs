﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Helper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Enums;
using OrganisationArchive.DAL.Models;

namespace OrganisationArchive.Controllers
{
    public class PersonController : Controller
    {
        IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        public IActionResult People()
        {
            IEnumerable<Person> people = personService.getPeople();
            return View(people);
        }
        [HttpGet]
        public IActionResult AddPerson()
        {
            ViewBag.Gender = typeof(Gender).GetAllEnumNames();
            ViewBag.City = typeof(City).GetAllEnumNames();
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson([Bind("Id,Name,Lastname,Gender,PersonalNumber,DateOfBirth,City,PhoneNumber")]Person person)
        {
            if (ModelState.IsValid)
            {

                personService.AddPerson(person);
                return RedirectToAction("People", person );
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            ViewBag.Gender = typeof(Gender).GetAllEnumNames();
            ViewBag.City = typeof(City).GetAllEnumNames();

            var person  = personService.GetPersonById(Id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                personService.UpdatePerson(person);

                return Redirect(Url.Action("People", "Person"));
            }
            return View(person.Id);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var person = personService.GetPersonById(Id);
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var person = personService.GetPersonById(Id);
            personService.DeletePerson(person);
            return Redirect(Url.Action("People", "Person"));
        }

        [HttpPost]
        public IActionResult UploadPhoto(Person person)
        {
            //var personWithPhoto = person;
            personService.UploadPhoto(person);
            return RedirectToAction("Edit", new { id = person.Id });

        }





    }
}