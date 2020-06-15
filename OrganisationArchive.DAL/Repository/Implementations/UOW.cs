using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Implementations
{
    public class UOW : IUOW
    {
        private OrganizationDbContext _context;
        private IPersonRepository _personRepository;
        private IOrganizationRepository _organizationRepository;
        private IEmployeeRepository _employeeRepository;

        public UOW(OrganizationDbContext context)
        {
            _context = context;
        }

        public IPersonRepository Person
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository(_context);
                return _personRepository;
            }
        }

        public IOrganizationRepository Organization
        {
            get
            {
                if (_organizationRepository == null)
                    _organizationRepository = new OrganizationRepository(_context);
                return _organizationRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_context);
                return _employeeRepository;
            }
        }
        public void commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
