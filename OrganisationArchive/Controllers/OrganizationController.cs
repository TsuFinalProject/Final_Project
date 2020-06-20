using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DataTransfer;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.Models;

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
           var organization = _organizationService.GetOrganizationsWithEmployee();
            return View(organization);
        }

        public ActionResult Details(int id)
        {
            var organization=_organizationService.GetOrganizationById(id);
            return View(organization);
        }

        public ActionResult Create()
        {
            var orgVM = new OrganizationVM();
            orgVM.OrgComponents = _organizationService.GetSelectListComponents();
            return View(orgVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationVM organization)
        {
            if(!ModelState.IsValid)
            {
                organization.OrgComponents = _organizationService.GetSelectListComponents();
                return RedirectToAction(nameof(Organizations));
            }
            _organizationService.AddOrganization(organization.OrganizationForm);
            return RedirectToAction("Organizations");
        }

        public ActionResult Edit(int id)
        {
            var organization = _organizationService.GetOrganizationById(id);
            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,OrganizationVM organization)
        {
            try
            {
                _organizationService.UpdateOrganization(organization.OrganizationForm);
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
        public ActionResult Delete(int id, OrganizationVM organization)
        {
            try
            {
                _organizationService.DeleteOrganization(organization.OrganizationForm);
                return RedirectToAction(nameof(Organizations));
            }
            catch
            {
                return View();
            }
        }
    }
}