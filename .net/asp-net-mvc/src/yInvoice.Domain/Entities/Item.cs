using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yInvoice.Domain.Entities
{
    public class Item: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public User Client { get; set; }
    }
}
