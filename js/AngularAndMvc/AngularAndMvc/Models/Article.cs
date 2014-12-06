using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularAndMvc.Models
{
    public class Article
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}