using bitrack.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private DataContext _context;
        private DbSet<T> _set;
        public Repository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return _set;
        }

        public T GetById(int ID)
        {
            return _set.Find(ID);
        }

        public void RemoveById(int ID)
        {
            _set.Remove(GetById(ID));
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }
    }
}
