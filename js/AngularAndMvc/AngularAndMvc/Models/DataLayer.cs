using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularAndMvc.Models
{
    public class DataLayer:DbContext
    {
        public DataLayer() : base("news") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Article> Articles { get; set; }
    }
}