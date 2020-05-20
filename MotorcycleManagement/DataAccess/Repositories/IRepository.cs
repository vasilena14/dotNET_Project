using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    interface IRepository<T> where T : Model
    {
        void CreateOrUpdate(T entity);

        void Delete(int id);

        T GetByID(int id);

        List<T> GetAll();
    }
}
