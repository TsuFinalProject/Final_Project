using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using SharpDX.WIC;
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
            UOW.Person.AddpersonDefaultPic(person);
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

        public Person UploadPhoto(Person person)
        {
            var uploads = Path.Combine(Environment.CurrentDirectory, "wwwroot/images");
            var ImageName = RandomString(10)+ '.' + person.ImageFile.FileName.Split('.').Last();
            var filePath = Path.Combine(uploads, ImageName);
            person.Image = ImageName;
            UpdatePerson(person);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                person.ImageFile.OpenReadStream();
                //person.ImageFile.CopyToAsync(fileStream);
                person.ImageFile.CopyTo(fileStream);
            }
            return person;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
