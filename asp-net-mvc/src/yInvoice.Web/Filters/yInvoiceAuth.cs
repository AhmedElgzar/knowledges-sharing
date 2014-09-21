using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yInvoice.DataLayer.Modules;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.Web.Filters
{
    //*** USE SimpleMembership in your projects ****
    public class yInvoiceAuth: ActionFilterAttribute
    {
        public UserRole[] Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool hasAccess = false;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (Roles.Length > 0)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterModule(new DataLayerModule());
                    var container = builder.Build();
                    var users = container.Resolve<IUserRepository>();
                    var user = users.GetAll().Where(u => u.Login == filterContext.HttpContext.User.Identity.Name).First();
                    hasAccess = Roles.Contains((UserRole)user.Role);
                }
                else
                {
                    hasAccess = true;
                }
            }

            if (!hasAccess)
            {
                filterContext.HttpContext.Response.Redirect("~/Account/Login");
                filterContext.HttpContext.Response.Flush();
                filterContext.HttpContext.Response.End();
                filterContext.Result = new HttpUnauthorizedResult();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}