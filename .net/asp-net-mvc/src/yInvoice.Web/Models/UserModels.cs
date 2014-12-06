using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yInvoice.Domain.Entities;

namespace yInvoice.Web.Models
{
    public class UserEditModel
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[\w+\.\-]+@[\w+\.\-]+\.[\w+\-]{2,4}$", ErrorMessage = "Email has wrong format")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int CompanyID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Role { get; set; }
                
        public List<SelectListItem> Roles 
        { 
            get 
            {
                return (from e in (UserRole[])Enum.GetValues(typeof(UserRole))
                 select new SelectListItem() { Value = ((int)e).ToString(), Text = e.ToString() }
                ).ToList();
            } 
        }
    }
}