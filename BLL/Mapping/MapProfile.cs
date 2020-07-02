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
                .ForMember(to =>
                    to.Employees,
                  from => from.MapFrom(src => src.Employees.Select(x => $"{x.Person.Name} {x.Person.Lastname }").ToList()));
            CreateMap<OrganizationDTO, Organization>()
                .ForMember(to =>
                    to.Id,
                  from => from.MapFrom(src => src.Id))
                  .ForMember(to =>
                    to.Name,
                  from => from.MapFrom(src => src.Name))
                  .ForMember(to =>
                    to.Work,
                  from => from.MapFrom(src => src.Work))
                  .ForMember(to =>
                    to.Address,
                  from => from.MapFrom(src => src.Address))
                  ;
            CreateMap<Organization, OrganizationForm>()
                 .ForMember(to =>           
                    to.EmployeeId,
                    from => from.MapFrom(src => src.Employees.Select(x => x.PersonId).FirstOrDefault()));


        }
    }
}
