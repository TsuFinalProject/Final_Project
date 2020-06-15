using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
