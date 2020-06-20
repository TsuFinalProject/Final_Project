using Microsoft.EntityFrameworkCore;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Implementations
{
    public class OrganizationRepository: RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(OrganizationDbContext context):base(context)
        {
        }

        public IEnumerable<Organization> GetAllOrganizationsWithEmployee()
        {  
            return _context.Organizations
                .Include(x => x.Employees)
                .ThenInclude(x => x.Person);
        }

        public Organization GetOrganizationWithEmployeeById(int Id)
        {
            return _context.Organizations
                .Where(x=>x.Id==Id)
                .Include(x => x.Employees)
                .ThenInclude(x => x.Person)
                .FirstOrDefault();
        }
    }
}
