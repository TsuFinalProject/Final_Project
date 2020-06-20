using AutoMapper;
using BLL.DataTransfer;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private IUOW _UOW;
        private IMapper _mapper;

        public OrganizationService(IUOW UOW,IMapper mapper)
        {
            _UOW = UOW;
            _mapper = mapper;
        }
        public void AddOrganization(OrganizationForm organization)
        {
            var org = _mapper.Map<Organization>(organization);
            _UOW.Organization.Create(org);
            _UOW.commit();
        }

        public void DeleteOrganization(OrganizationForm organization)
        {
            var org = _mapper.Map<Organization>(organization);
            _UOW.Organization.Delete(org);
            _UOW.commit();
        }

        public OrganizationForm GetOrganizationById(int Id)
        {
            var org = _UOW.Organization.GetOrganizationWithEmployeeById(Id);
            return _mapper.Map<OrganizationForm>(org);
        }

        public IEnumerable<OrganizationDTO> GetOrganizationsWithEmployee()
        {
            var orgs =  _UOW.Organization.GetAllOrganizationsWithEmployee();
            return _mapper.Map<IEnumerable<OrganizationDTO>>(orgs);
        }
        public void UpdateOrganization(OrganizationForm organization)
        {
            var dbModel = _UOW.Organization.GetOrganizationWithEmployeeById(organization.Id);
            _mapper.Map<OrganizationForm, Organization>(organization, dbModel);
            _UOW.Organization.Update(dbModel);
            _UOW.commit();
        }
        public SelectListOrg GetSelectListComponents()
        {
            SelectListOrg model = new SelectListOrg();
            var persons = _UOW.Person.FindAll();


            model.EmployeeList = persons.Select(x =>
              new SelectListItem()
              { Text = $"{x.Name} {x.Lastname}", Value = x.Id.ToString() }).ToList();

            return model;
        }
    }
}
