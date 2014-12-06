using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using yInvoice.DataLayer.Modules;
using yInvoice.Domain.Repositories;

namespace yInvoice.Web.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Menu<T>(this HtmlHelper<T> helper, string user)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataLayerModule());
            var container = builder.Build();
            var users = container.Resolve<IUserRepository>();
            var model = users.GetAll().Where(u => u.Login == user).FirstOrDefault();
            return helper.Partial("~/Views/Shared/Menu.cshtml", model);
        }
    }
}