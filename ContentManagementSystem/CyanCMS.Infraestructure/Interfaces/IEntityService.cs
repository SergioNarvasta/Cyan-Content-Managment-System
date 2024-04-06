using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanCMS.Infraestructure.Interfaces
{
    public interface IEntityService<T> where T : class, new()
    {
        Task<T> Get(params object[] id);
        IEnumerable<T> FindAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
