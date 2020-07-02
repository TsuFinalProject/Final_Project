using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.DataTransfer
{
    public class SelectListOrg
    {
        public List<SelectListItem> EmployeeList { get; set; }
        public List<SelectListItem> PositionList { get; set; }
    }
}
