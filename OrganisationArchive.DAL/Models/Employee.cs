using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrganisationArchive.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int PersonId{ get; set; }
        public int OrganizationId { get; set; }
        public string Position { get; set; }
        public Person Person { get; set; }
        public Organization Organization { get; set; }
    }
}
