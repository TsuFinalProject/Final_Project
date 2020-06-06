using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrganisationArchive.DAL.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Work { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
