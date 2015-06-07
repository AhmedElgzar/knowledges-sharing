using bitrack.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    internal class EventRepository: Repository<Event>, IEventRepository
    {
        private DataContext _context;
        public EventRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
