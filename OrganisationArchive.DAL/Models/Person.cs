using Microsoft.AspNetCore.Http;
using OrganisationArchive.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrganisationArchive.DAL.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string PersonalNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

