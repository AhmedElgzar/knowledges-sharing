using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain
{
    public class PageFilter
    {
        public List<PageFilterCondition> Filters { get; set; }
        public int Page { get; set; }
        public int CountPerPage { get; set; }
        public SortOrder SortType { get; set; }
        public string SortField { get; set; }
    }

    public class PageFilterCondition
    {
        public FilterTypes FilterType { get; set; }
        public string FilterField { get; set; }
        public string Term { get; set; }
    }
}