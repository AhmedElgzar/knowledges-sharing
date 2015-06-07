using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Goals
{
    public class GoalLog : IEntity
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public int GoalID { get; set; }

        [ForeignKey("GoalID")]
        public Goal Goal { get; set; }
    }
}
