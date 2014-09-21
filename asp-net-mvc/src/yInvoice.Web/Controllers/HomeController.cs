using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;
using yInvoice.Web.Filters;

namespace yInvoice.Web.Controllers
{
    public class HomeController : Controller
    {
        ICompanyRepository _companies;
        public HomeController(ICompanyRepository companies)
        {
            _companies = companies;
        }
        public ActionResult Index()
        {            
            var list = _companies.GetAll().ToList();
            return View();
        }

        [yInvoiceAuth(Roles=new UserRole[]{UserRole.Admin, UserRole.StaffMember})]
        public ActionResult TestAuth()
        {            
            var list = _companies.GetAll().ToList();
            return View();
        }
    }
}
