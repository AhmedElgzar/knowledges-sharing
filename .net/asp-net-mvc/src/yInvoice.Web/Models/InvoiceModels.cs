using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yInvoice.Domain.Entities;

namespace yInvoice.Web.Models
{
    public class InvoiceEditModel
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int CompanyID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public List<InvoiceItem> Items { get; set; }        
        public Company Company { get; set; }        
        public User Client { get; set; }

        public List<SelectListItem> Statuses
        {
            get
            {
                return (from e in (Statuses[])Enum.GetValues(typeof(Statuses))
                        select new SelectListItem() { Value = ((int)e).ToString(), Text = e.ToString() }
                ).ToList();
            }
        }
    }
}