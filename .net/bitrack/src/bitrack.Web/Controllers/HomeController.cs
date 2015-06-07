using bitrack.Domain;
using bitrack.Domain.Pageviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bitrack.Web.Controllers
{
    public class HomeController : Controller
    {
        IPageviewRepository _pageviewRepository;
        PageviewService _pageviewService;
        public HomeController(IPageviewRepository pageviewRepository)
        {
            _pageviewRepository = pageviewRepository;
            _pageviewService = new PageviewService(_pageviewRepository);
        }
        public ActionResult Index()
        {
            //var pageviews = _pageviewRepository.GetAll().ToList();
            var pageviews = _pageviewService.GetByFilter(new PageFilter()
            {
                Filters = new List<PageFilterCondition>()
                {
                    new PageFilterCondition {
                        FilterField = "Name",
                        Term = "test",
                        FilterType = FilterTypes.Equal
                    },
                    new PageFilterCondition {
                        FilterField = "",
                        Term = "30",
                        FilterType = FilterTypes.Equal
                    },
                },
                CountPerPage = 10,
                Page = 0,
                SortField = "Name",
                SortType = SortOrder.Desc
            });
            return View();
        }
    }
}