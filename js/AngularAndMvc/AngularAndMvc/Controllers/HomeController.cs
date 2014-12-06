using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularAndMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult List()
        {
            return PartialView();
        }
        
        public ActionResult Edit()
        {
            return PartialView();
        }
               
    }
}
