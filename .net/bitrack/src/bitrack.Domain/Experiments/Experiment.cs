using bitrack.Domain.Goals;
using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Experiments
{
    public class Experiment : IEntity, IAggregationRoot
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int TrafficPercent { get; set; }
        public int DurationType { get; set; }
        public bool IsActive { get; set; }
        public int GoalID { get; set; }

        [ForeignKey("GoalID")]
        public Goal Goal { get; set; }
    }
}
