using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Repositories
{
    internal class CompanyRepository:Repository<Company>, ICompanyRepository
    {
        InvoiceDbContext _context;
        public CompanyRepository(InvoiceDbContext context) : base(context) { _context = context; }
    }
}
