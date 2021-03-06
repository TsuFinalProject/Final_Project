﻿using Microsoft.AspNetCore.Http;
using OrganisationArchive.DAL.CustomValidations;
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
        [RegularExpression(@"[A-Za-z]{1,20}$",
         ErrorMessage = "Invalid First Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{1,30}$",
         ErrorMessage = "Invalid Lastname")]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "It must be  11 characters")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid Peorsonal Number")]
        public string PersonalNumber { get; set; }
        //ValidateStartDate = true,
        [Required]
        [DataType(DataType.Date)]
        [CorrectDate( ErrorMessage = "Birth date shouldn't be greater than the current date")]
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        public ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

