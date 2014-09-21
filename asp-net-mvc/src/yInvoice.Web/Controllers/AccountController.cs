using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using yInvoice.Domain.Repositories;
using yInvoice.Web.Models;

namespace yInvoice.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository _users;
        public AccountController(IUserRepository users)
        {
            _users = users;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model)
        {            
            if (ModelState.IsValid)
            {
                var encyptedPass = Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(model.Password)));
                var user = _users.GetAll().Where(u => u.Login == model.Login && u.Password == encyptedPass).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("LoginFailed", "Wrong login or password");
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}