using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
       
            IEnumerable<T> FindAll();

            T Get(int id);

            T Create(T entity);

            void Update(T entity);

            void Delete(T entity);
    }
}
