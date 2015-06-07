using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        //IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = "");
        T GetById(int ID);
        void RemoveById(int ID);
        void Remove(T entity);
    }
}
