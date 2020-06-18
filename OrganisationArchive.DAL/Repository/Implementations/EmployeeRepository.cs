using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Implementations
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
       
        public EmployeeRepository(OrganizationDbContext context)
            : base(context)
        { }

        public IEnumerable<Employee> GetAllEmplyee()
        {
            return _context.Employees
                .Include(p => p.Organization)
                .Include(p => p.Person)
                .AsNoTracking();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _context.Employees
                .Include(p => p.Organization)
                .Include(p => p.Person)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == Id);
        }
    }
}
