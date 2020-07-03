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
        OrganizationDTO GetOrganizationById(int Id); 
        void DeleteOrganization(int Id); 
        void UpdateOrganizationWithoutEmpl(OrganizationDTO organization);
        void UpdateOrganization(EmployeeBinder organization); 
        OrganizationDTO AddOrganization(OrganizationDTO organization); 
        SelectListOrg GetSelectListComponents(); 
        IEnumerable<OrganisationArchive.DAL.Models.Organization> GetOrganizations(); 
        EmployeeBinder GetOrganizationWithEmpById(int id); 
        bool IsValid(OrganizationDTO organization);
    }
}
