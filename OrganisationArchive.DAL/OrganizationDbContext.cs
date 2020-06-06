using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL
{
    public class OrganizationDbContext : DbContext
    {
        public OrganizationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
