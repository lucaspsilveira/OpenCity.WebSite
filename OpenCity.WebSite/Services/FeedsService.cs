using CodeHollow.FeedReader;
using System.Collections.Generic;

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
            var feedAplateia = FeedReader.ReadAsync("http://www.aplateia.com.br/feed/atom/");
            var feedSentinela = FeedReader.ReadAsync("https://www.sentinela24h.com/blog-feed.xml");
            List<Feed> feeds = new List<Feed>
            {
                feedAplateia.Result,
                feedSentinela.Result
            };
            return feeds;
        }
    }
}
