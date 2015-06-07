using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    internal class WebsiteRepository : Repository<Website>, IWebsiteRepository
    {
        private DataContext _context;
        public WebsiteRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
