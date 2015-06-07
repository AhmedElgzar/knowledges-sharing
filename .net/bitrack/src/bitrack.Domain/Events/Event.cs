using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Events
{
    public class Event : IEntity, IAggregationRoot
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int WebsiteID { get; set; }

        [ForeignKey("WebsiteID")]
        public Website Website { get; set; }
        public virtual List<EventLog> EventLogs { get; set; }

        public void AddLog(EventLog log)
        {
            EventLogs.Add(log);
        }
    }
}
