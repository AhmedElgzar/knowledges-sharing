using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using yInvoice.DataLayer.Repositories;
using yInvoice.Domain.Entities;

namespace yInvoice.Web
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<InvoiceDbContext>
    {
        protected override void Seed(InvoiceDbContext context)
        {
            //we'll not work on multiple companies, so company and defult admin specified automatically
            var company = new Company()
            {
                Adress = "test 12, 123",
                City = "test city",
                Country = "Ukraine",
                Name = "test company",
                Phone = "093-123-12-1",
                Zip = "12312"
            };
            company.Users = new List<User>();
            company.Users.Add(new User()
            {
                Name = "admin",
                Role = (int)UserRole.Admin,
                Login = "admin",
                Password = Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes("password")))
            });
            context.Companies.Add(company);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}