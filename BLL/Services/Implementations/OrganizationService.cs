using AutoMapper;
using BLL.DataTransfer;
using BLL.Services.Helper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganisationArchive.DAL.Enums;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Organization = OrganisationArchive.DAL.Models.Organization;

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
        public OrganizationDTO AddOrganization(OrganizationDTO organization)
        {
            var org = _mapper.Map<Organization>(organization);
            var createdOrganization = _UOW.Organization.Create(org);
            _UOW.commit();
            return _mapper.Map<OrganizationDTO>(createdOrganization);
        }

        public void DeleteOrganization(int Id)
        {
            
            _UOW.Organization.Delete(_UOW.Organization.GetOrganizationWithEmployeeById(Id));
            _UOW.commit();
        }

        public OrganizationDTO GetOrganizationById(int Id)
        {
            var org = _UOW.Organization.GetOrganizationWithEmployeeById(Id);
            return _mapper.Map<OrganizationDTO>(org);
        }
        public void UpdateOrganization(EmployeeBinder organization)
        {
            var dbModel = _UOW.Organization.GetOrganizationWithEmployeeById(organization.Id);
            dbModel.Employees.Add(new Employee()
            {
                PersonId = organization.EmployeeId,
                Position = organization.position
            });
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
            model.PositionList = typeof(Position).GetAllEnumNames().Select(x => new SelectListItem()
            {
                Text = x,
                Value = x
            }).ToList() ;
            return model;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
           var organizations = _UOW.Organization.GetAllOrganizationsWithEmployee();
            return (organizations);
        }

        public void UpdateOrganizationWithoutEmpl(OrganizationDTO organization)
        {
            var dbModel = _UOW.Organization.GetOrganizationWithEmployeeById(organization.Id);
            dbModel.Address = organization.Address;
            dbModel.Name = organization.Name;
            dbModel.Work = organization.Work;
            _UOW.Organization.Update(dbModel);
            _UOW.commit();
        }

        public EmployeeBinder GetOrganizationWithEmpById(int id)
        {
            var org = _UOW.Organization.GetOrganizationWithEmployeeById(id);
            return _mapper.Map<EmployeeBinder>(org);
        }

        public bool IsValid(OrganizationDTO organization)
        {
            if((organization.Name.Length>0 && organization.Name.Length<=50) && (organization.Address.Length>5&& organization.Address.Length <= 100))
            {
                return true;
            }
            return false;
        }
    }
}
