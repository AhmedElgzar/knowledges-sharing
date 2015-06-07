using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using bitrack.Infrastructure.Domain;

namespace bitrack.Domain.Pageviews
{
    public class PageviewService
    {
        IPageviewRepository _pageviewRepository;
        public PageviewService(IPageviewRepository pageviewRepository)
        {
            _pageviewRepository = pageviewRepository;
        }
        public List<Pageview> GetByFilter(PageFilter filter = null)
        {
            //Contract.Requires(!string.IsNullOrEmpty(f.FilterField), "Specify filter filed name");
            Contract.Requires(filter == null || filter.CountPerPage > 0, "Specify filter filed name");
            Contract.Requires(filter.SortType == SortOrder.None || !string.IsNullOrEmpty(filter.SortField), "Specify order filed name");

            var query = _pageviewRepository.GetAll();
            if (filter != null)
            {
                foreach(var f in filter.Filters)
                {
                    query = query.CustomWhere(f.FilterField, f.FilterType.ToString(), f.Term);
                }

                if (filter.SortType != SortOrder.None)
                {
                    query = query.OrderBy(string.Format("{0} {1}", filter.SortField, filter.SortType == SortOrder.Desc ? "descending" : string.Empty));
                }
                else
                {
                    //Skip requiresordering
                    query = query.OrderBy(q => q.ID);
                }
                query = query.Skip(filter.Page * filter.CountPerPage).Take(filter.CountPerPage);
            }
            return query.ToList();
        }
    }
}
