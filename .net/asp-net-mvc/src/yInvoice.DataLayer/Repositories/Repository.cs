using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Repositories
{
    public abstract class Repository<T>: IRepository<T> where T: class, IEntity
    {
        InvoiceDbContext _context;
        DbSet<T> _set;
        public Repository(InvoiceDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public void Add(T entry)
        {
            _set.Add(entry);
        }

        public void Update(T entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _set;
        }

        public void RemoveById(int id)
        {
            _set.Remove(GetById(id));
        }

        public void Remove(T entry)
        {
            _set.Remove(entry);
        }
    }
}
