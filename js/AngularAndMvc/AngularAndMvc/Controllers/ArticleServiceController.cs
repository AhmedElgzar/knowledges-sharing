using AngularAndMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularAndMvc.Controllers
{
    public class ArticleServiceController : ApiController
    {
        DataLayer dl = new DataLayer();

        public List<Article> GetAll()
        {
            return dl.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return dl.Articles.Find(id);
        }

        [HttpPost]
        public void Create(Article article)
        {
            dl.Articles.Add(article);
            dl.SaveChanges();
        }

        [HttpPut]
        public void Update(Article article)
        {
            dl.Entry(article).State=System.Data.EntityState.Modified;
            dl.SaveChanges();
        }

        [HttpDelete]
        public void Create(int id)
        {
            dl.Articles.Remove(dl.Articles.Find(id));
            dl.SaveChanges();
        }
    }
}
