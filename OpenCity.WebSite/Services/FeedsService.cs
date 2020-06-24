using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCity.WebSite.Services
{
    public class FeedsService
    {
        
        public async IAsyncEnumerable<Feed> GetFeedAsync(string Url)
        {
            var feed = await FeedReader.ReadAsync(Url);
            yield return feed;
        }

        public IEnumerable<Feed> GetFeeds()
        {
            var feed = FeedReader.ReadAsync("http://www.aplateia.com.br/feed/atom/");
            var feed2 = FeedReader.ReadAsync("https://www.sentinela24h.com/blog-feed.xml");
            List<Feed> feeds = new List<Feed>
            {
                feed.Result,
                feed2.Result
            };
            return feeds;
        }
    }
}
