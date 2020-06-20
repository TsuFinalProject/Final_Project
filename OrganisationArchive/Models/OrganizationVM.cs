using BLL.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganisationArchive.Models
{
    public class OrganizationVM
    {
        public OrganizationForm OrganizationForm { get; set; }
        public SelectListOrg OrgComponents { get; set; }
    }
}
