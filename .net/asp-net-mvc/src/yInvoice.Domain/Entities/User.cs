using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yInvoice.Domain.Entities
{
    public class User: IEntity
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int CompanyID { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
