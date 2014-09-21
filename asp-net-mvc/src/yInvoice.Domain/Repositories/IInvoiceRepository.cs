using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;

namespace yInvoice.Domain.Repositories
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
    }
}
