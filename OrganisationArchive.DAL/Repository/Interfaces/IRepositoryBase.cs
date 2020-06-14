using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL.Repository
{
    public interface IRepositoryBase<T>
    {
       
            IEnumerable<T> FindAll();

            T Get(int id);

            void Create(T entity);

            void Update(T entity);

            void Delete(T entity);
    }
}
