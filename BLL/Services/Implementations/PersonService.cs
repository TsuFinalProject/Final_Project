using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private IUOW UOW { get; }

        public PersonService(IUOW UOW)
        {
            this.UOW = UOW;
        }

        public void AddPerson(Person person)
        {
            UOW.Person.Create(person);
            UOW.commit();
        }

        public IEnumerable<Person> getPeople()
        {
            return UOW.Person.FindAll();
        }

        public Person GetPersonById(int Id)
        {
            return UOW.Person.Get(Id);
        }

        public void DeletePerson(Person person)
        {
            UOW.Person.Delete(person);
            UOW.commit();
        }

        public void UpdatePerson(Person person)
        {
            UOW.Person.Update(person);
            UOW.commit();
        }

        public void UploadPhoto(Person person)
        {
            var uploads = Path.Combine(Environment.CurrentDirectory, "wwwroot/images/ProfilePhotos");
            var ImageName = Path.GetRandomFileName() + '.' + person.ImageFile.FileName.Split('.').Last();
            var filePath = Path.Combine(uploads, ImageName);
            person.Image = ImageName;
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                person.ImageFile.CopyToAsync(fileStream);
            }
        }
    }
}
