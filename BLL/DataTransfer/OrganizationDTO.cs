using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DataTransfer
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^.{1,50}$")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^.{1,100}$")]
        public string Address { get; set; }
        [Required]
        public string Work { get; set; }
        public List<string> Employees { get; set; }
        
    }
}
