using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Websites
{
    public class WebsiteUser: IEntity, IAggregationRoot
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool IsOwner { get; set; }
        public int WebsiteID { get; set; }
        [ForeignKey("WebsiteID")]
        public Website Website { get; set; }

        /*Todo manage users?*/
    }
}
