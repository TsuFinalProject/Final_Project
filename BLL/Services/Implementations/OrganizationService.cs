using BLL.Services.Interfaces;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private IUOW _UOW;

        public OrganizationService(IUOW UOW)
        {
            _UOW = UOW;
        }
        public void AddOrganization(Organization organization)
        {
            _UOW.Organization.Create(organization);
            _UOW.commit();
        }

        public void DeleteOrganization(Organization organization)
        {
            _UOW.Organization.Delete(organization);
            _UOW.commit();
        }

        public Organization GetOrganizationById(int Id)
        {
            return _UOW.Organization.Get(Id);
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _UOW.Organization.FindAll();
        }

        public void UpdateOrganization(Organization organization)
        {
            _UOW.Organization.Update(organization);
            _UOW.commit();
        }
    }
}
