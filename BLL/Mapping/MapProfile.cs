using AutoMapper;
using BLL.DataTransfer;
using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Organization, OrganizationDTO>()
                .ForMember(from =>
                    from.Employees,
                    to => to.MapFrom(src => src.Employees.Select(x => $"{x.Person.Name} {x.Person.Lastname }").ToList()));
            CreateMap<OrganizationForm, Organization>()
                .ForMember(from =>
                    from.Employees,
                    to => to.MapFrom(src => src.EmployeeIds.Select(x => new Employee() { PersonId = x ,Position=src.position})));

            CreateMap<Organization, OrganizationForm>()
                 .ForMember(from =>
                    from.EmployeeIds,
                    to => to.MapFrom(src => src.Employees.Select(x => x.PersonId).ToList()));
        }
    }
}
