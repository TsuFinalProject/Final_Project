using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Models;

namespace OrganisationArchive.Controllers
{
    public class OrganizationController : Controller
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        public ActionResult Organizations()
        {
           var organization = _organizationService.GetOrganizations();
            return View(organization);
        }

        public ActionResult Details(int id)
        {
            var organization=_organizationService.GetOrganizationById(id);
            return View(organization);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            try
            {
                _organizationService.AddOrganization(organization);
                return RedirectToAction(nameof(Organizations));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var organization = _organizationService.GetOrganizationById(id);
            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Organization organization)
        {
            try
            {
                _organizationService.UpdateOrganization(organization);
                return RedirectToAction(nameof(Organizations));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var organization = _organizationService.GetOrganizationById(id);
            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Organization organization)
        {
            try
            {
                _organizationService.DeleteOrganization(organization);
                return RedirectToAction(nameof(Organizations));
            }
            catch
            {
                return View();
            }
        }
    }
}