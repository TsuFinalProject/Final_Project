using OrganisationArchive.DAL.Models;
using OrganisationArchive.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Implementations
{
    public class OrganizationRepository: RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(OrganizationDbContext context):base(context)
        {
        }
    }
}
