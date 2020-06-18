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

        public Person AddpersonDefaultPic(Person person)
        {
            person.Image = "no-image.kgb.png";
            var per = _context.People.Add(person);
            return per.Entity;
        }

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
