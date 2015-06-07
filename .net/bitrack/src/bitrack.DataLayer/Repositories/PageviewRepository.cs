using bitrack.Domain.Pageviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    internal class PageviewRepository : Repository<Pageview>, IPageviewRepository
    {
        private DataContext _context;
        public PageviewRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
