using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;

namespace yInvoice.DataLayer.Repositories
{
    public class InvoiceDbContext:DbContext, IUnitOfWork
    {
        public InvoiceDbContext() : base("InvoiceDb") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasRequired(u => u.Company).WithMany(c => c.Users).WillCascadeOnDelete(false);
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  
            base.OnModelCreating(modelBuilder);
        }
        public void Save()
        {
            SaveChanges();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
    }
}
