using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bitrack.Web.Areas.Internal.Models
{
    public class PageViewGridDTO
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<PageViewDTO> data { get; set; }
    }

    public class PageViewDTO
    {
        public string Name { get; set; }
        public string TotalVisits { get; set; }
        public string NewVisits { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }

    }
}