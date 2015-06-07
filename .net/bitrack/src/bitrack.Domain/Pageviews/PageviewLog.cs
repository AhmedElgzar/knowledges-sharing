using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Pageviews
{
    public class PageviewLog : IEntity
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid SessionId { get; set; }
        public string Browser { get; set; }
        public string IPAdress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string OS { get; set; }
        public string Language { get; set; }
        public int PageviewID { get; set; }
        public int? RefferID { get; set; }
        public int Duration { get; set; }

        [ForeignKey("PageviewID")]
        public Pageview Pageview { get; set; }
        [ForeignKey("RefferID")]
        public PageviewLog Reffer { get; set; }
    }
}
