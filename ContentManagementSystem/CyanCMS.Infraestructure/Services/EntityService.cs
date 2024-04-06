using CyanCMS.Infraestructure.Data;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanCMS.Infraestructure.Services
{
    public class EntityService<T> : IEntityService<T> where T : class, new()
    {

        protected readonly AppDbContext _context;

        public EntityService()
        {
            this._context = new AppDbContext();
        }

        public virtual void Add(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
                _context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual async Task<T> Get(params object[] id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return Table;
        }

        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task Save()
        {
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }

    }
}
