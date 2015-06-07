using bitrack.Domain;
using bitrack.Domain.Events;
using bitrack.Domain.Experiments;
using bitrack.Domain.Goals;
using bitrack.Domain.Pageviews;
using bitrack.Domain.Websites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.DataLayer.Repositories
{
    public class DataContext: DbContext, IUnitOfWork
    {
        public DataContext() : base("BiTrackConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Goal>().HasRequired(g => g.Website).WithMany(g => g.Goals).WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }

        public DbSet<Website> Websites { get; set; }
        public DbSet<WebsiteUser> WebsiteUsers { get; set; }
        public DbSet<Pageview> Pageviews { get; set; }
        public DbSet<PageviewLog> PageviewLogs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalLog> GoalLogs { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentVariation> ExperimentVariations { get; set; }
        public DbSet<ExperimentVariationLog> ExperimentLogs { get; set; }
    }
}
