using bitrack.Domain.Experiments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    internal class ExperimentRepository: Repository<Experiment>, IExperimentRepository
    {
        private DataContext _context;
        public ExperimentRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
