using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Repositories
{
    internal class ItemRepository:Repository<Item>, IItemRepository
    {
        InvoiceDbContext _context;
        public ItemRepository(InvoiceDbContext context) : base(context) { _context = context; }
    }
}
