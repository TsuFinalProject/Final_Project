using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Implementations
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(OrganizationDbContext context)
            : base(context)
                { }

        public IEnumerable<Person> GetPeopleWithJoin()
        {
            return _context.People.Include(x => x.Employees);
        }

        public Person GetPersonById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
