using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yInvoice.Web.Models
{
    public class AccountModel
    {
        [Required]
        [DisplayName("Your Login")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Your Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}