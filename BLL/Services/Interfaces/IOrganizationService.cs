using BLL.DataTransfer;
using OrganisationArchive.DAL.Migrations;
using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IOrganizationService
    {
        IEnumerable<OrganizationDTO> GetOrganizationsWithEmployee();
        OrganizationForm GetOrganizationById(int Id);
        void DeleteOrganization(OrganizationForm organization);
        void UpdateOrganization(OrganizationForm organization);
        void AddOrganization(OrganizationForm organization);
        SelectListOrg GetSelectListComponents();
        IEnumerable<OrganisationArchive.DAL.Models.Organization> GetOrganizations();
    }
}
