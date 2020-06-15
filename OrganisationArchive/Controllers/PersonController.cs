﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson([Bind("Id,Name,Lastname,Gender,PersonalNumber,DateOfBirth,City,PhoneNumber")]Person person)
        {
            if (ModelState.IsValid)
            {
                Person AddPerson = new Person();
                AddPerson = person;
                personService.AddPerson(AddPerson);
                
                return View(nameof(People));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var person  = personService.GetPersonById(Id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            personService.UpdatePerson(person);

            return Redirect(Url.Action("People", "Person"));
        }
    }
}