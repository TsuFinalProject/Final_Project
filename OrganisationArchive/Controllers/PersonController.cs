using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Helper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Enums;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.Models;

namespace OrganisationArchive.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonController : Controller
    {
        IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        public async Task<IActionResult> People(
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewBag.CurrentFilter = searchString;

            var people = personService.getPeople();
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(x => x.Name.ToUpperInvariant().Contains(searchString.ToUpperInvariant()) || x.Lastname.ToUpperInvariant().Contains(searchString.ToUpperInvariant()) || x.PersonalNumber.Contains(searchString));
            }
            var pageSize = 4;
            var pagination = await PaginatedList<Person>.CreateAsync(people, pageNumber ?? 1, pageSize);
            return View(pagination);
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
            ViewBag.Gender = typeof(Gender).GetAllEnumNames();
            ViewBag.City = typeof(City).GetAllEnumNames();
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
            ViewBag.Gender = typeof(Gender).GetAllEnumNames();
            ViewBag.City = typeof(City).GetAllEnumNames();
            return View(person);
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
            if (person.ImageFile == null)
            {
                return RedirectToAction("Edit", new { id = person.Id });
            }
            //var personWithPhoto = person;
            personService.UploadPhoto(person);
            return RedirectToAction("Edit", new { id = person.Id });

        }





    }
}