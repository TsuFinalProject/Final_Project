using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DataTransfer
{
    public class EmployeeBinder
    {

        public int Id { get; set; }
        [DisplayName("Employees")]
        public int EmployeeId { get; set; }
        [DisplayName("Position")]
        public string position { get; set; }

    }
}
