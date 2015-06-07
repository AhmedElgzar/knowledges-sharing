using bitrack.Domain.Experiments;
using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Goals
{
    public class Goal: IEntity, IAggregationRoot
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public string Value { get; set; }
        public int WebsiteID { get; set; }

        [ForeignKey("WebsiteID")]
        public Website Website { get; set; }
        public virtual List<GoalLog> GoalLogs { get; set; }
        public void AddLog(GoalLog log)
        {
            GoalLogs.Add(log);
        }
    }
}
