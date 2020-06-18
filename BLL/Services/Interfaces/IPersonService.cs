using Microsoft.AspNetCore.Http;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> getPeople();
        Person GetPersonById(int Id);
        void DeletePerson(Person person);
        void UpdatePerson(Person person);
        void AddPerson(Person person);
        Person UploadPhoto(Person person);
    }
}
