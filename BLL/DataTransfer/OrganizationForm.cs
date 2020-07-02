using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DataTransfer
{
    public class OrganizationForm
    {

        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{1,50}$",ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^.{1,100}$")]
        public string Address { get; set; }
        [Required]
        public string Work { get; set; }
        [DisplayName("Employees")]
        public int EmployeeId { get; set; }
        [DisplayName("Position")]
        public string position { get; set; }

    }
}
