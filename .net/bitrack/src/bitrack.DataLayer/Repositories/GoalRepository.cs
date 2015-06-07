using bitrack.Domain.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    internal class GoalRepository : Repository<Goal>, IGoalRepository
    {
        private DataContext _context;
        public GoalRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
