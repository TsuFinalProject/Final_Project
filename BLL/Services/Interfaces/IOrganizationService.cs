using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetOrganizations();
        Organization GetOrganizationById(int Id);
        void DeleteOrganization(Organization organization);
        void UpdateOrganization(Organization organization);
        void AddOrganization(Organization organization);
    }
}
