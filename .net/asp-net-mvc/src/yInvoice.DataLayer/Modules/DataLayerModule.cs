using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.DataLayer.Repositories;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Modules
{
    public class DataLayerModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InvoiceItemRepository>().As<IInvoiceItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InvoiceDbContext>().As<IUnitOfWork>().As<InvoiceDbContext>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
