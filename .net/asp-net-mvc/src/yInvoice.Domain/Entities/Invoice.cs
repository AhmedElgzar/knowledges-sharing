using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yInvoice.Domain.Entities
{
    public class Invoice:IEntity
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int CompanyID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public List<InvoiceItem> Items { get; set; }
        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
        [ForeignKey("ClientID")]
        public User Client { get; set; }

    }
}
