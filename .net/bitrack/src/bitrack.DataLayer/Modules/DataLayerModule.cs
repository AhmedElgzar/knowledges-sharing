using Autofac;
using bitrack.DataLayer.Repositories;
using bitrack.Domain;
using bitrack.Domain.Events;
using bitrack.Domain.Experiments;
using bitrack.Domain.Goals;
using bitrack.Domain.Pageviews;
using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Modules
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventRepository>().As<IEventRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExperimentRepository>().As<IExperimentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GoalRepository>().As<IGoalRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PageviewRepository>().As<IPageviewRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WebsiteRepository>().As<IWebsiteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DataContext>().As<IUnitOfWork>().As<DataContext>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
