using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yInvoice.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entry);
        void Update(T entry);
        T GetById(int id);
        //TODO: shopud take Func to filter results
        IQueryable<T> GetAll();
        void RemoveById(int id);
        void Remove(T entry);
    }
}
