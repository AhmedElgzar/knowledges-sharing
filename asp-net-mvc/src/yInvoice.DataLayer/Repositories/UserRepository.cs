using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Repositories
{
    internal class UserRepository:Repository<User>, IUserRepository
    {
        InvoiceDbContext _context;
        public UserRepository(InvoiceDbContext context) : base(context) { _context = context; }
    }
}
