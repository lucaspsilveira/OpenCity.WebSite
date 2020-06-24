using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenCity.WebSite.Models;
using OpenCity.WebSite.Services;

namespace OpenCity.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public FeedsService FeedsService;
        public CityHallDataService CityHallDataService;

        public IEnumerable<Feed> Description { get; set; }

        public IAsyncEnumerable<Feed> Feed { get; set; }
        public IAsyncEnumerable<CityHallPublication> CityHallPosts { get; set; }
        public IEnumerable<Feed> Feeds { get; set; }

        public IndexModel(
                            ILogger<IndexModel> logger,
                            FeedsService feedsService,
                            CityHallDataService cityHallDataService
                            )
        {
            _logger = logger;
            FeedsService = feedsService;
            CityHallDataService = cityHallDataService;
        }

        public void OnGet()
        {
            //Feed = FeedsService.GetFeedAsync("http://www.aplateia.com.br/feed/atom/");
            Feeds = FeedsService.GetFeeds();
            CityHallPosts = CityHallDataService.GetPosts();
        }
    }
}
