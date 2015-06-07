using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Events
{
    public class EventLog : IEntity
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid SessionId { get; set; }
        public int EventID { get; set; }
        public string Category { get; set; }
        public string Action { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        //TODO: move to VO
        public string Browser { get; set; }
        public string IPAdress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string OS { get; set; }
        public string Language { get; set; }

        [ForeignKey("EventID")]
        public Event Event { get; set; }
    }
}
