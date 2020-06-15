using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Interfaces
{
    public interface IUOW : IDisposable
    {
        IPersonRepository Person {get;}
        IEmployeeRepository Employee { get;}
        IOrganizationRepository Organization { get; }
        void commit();
    }
}
