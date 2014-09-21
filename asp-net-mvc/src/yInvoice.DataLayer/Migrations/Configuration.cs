namespace yInvoice.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using yInvoice.Domain.Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<yInvoice.DataLayer.Repositories.InvoiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(yInvoice.DataLayer.Repositories.InvoiceDbContext context)
        {
            var company = new Company()
            {
                Adress = "test 12, 123",
                City = "test city",
                Country = "Ukraine",
                Name = "test",
                Phone = "093-123-12-1",
                Zip = "12312",
                Email = "general@company.com"
            };
            company.Users = new List<User>();
            company.Users.Add(new User()
            {
                Name = "admin",
                Role = (int)UserRole.Admin,
                Login = "admin",
                Password = Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes("password"))),
                Email = "admin@company.com"
            });
            context.Companies.Add(company);
            context.SaveChanges();
        }
    }
}
