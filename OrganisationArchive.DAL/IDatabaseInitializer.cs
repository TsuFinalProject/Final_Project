using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationArchive.DAL
{
    public interface IDatabaseInitializer
    {
        Task Seed();
    }
}
