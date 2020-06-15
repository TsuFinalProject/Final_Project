using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Interfaces
{
    public interface IPersonRepository: IRepositoryBase<Person>
    {
        IEnumerable<Person> GetPeopleWithJoin();
        Person GetPersonById(int Id);
    }
}
