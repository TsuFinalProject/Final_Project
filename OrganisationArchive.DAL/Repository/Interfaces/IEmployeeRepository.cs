using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository
{
   public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetAllEmplyee();
        Employee GetEmployeeById(int Id);
    }
}
