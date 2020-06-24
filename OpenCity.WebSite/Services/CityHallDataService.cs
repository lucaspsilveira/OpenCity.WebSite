using AngleSharp;
using AngleSharp.Dom;
using Microsoft.Extensions.Logging;
using OpenCity.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCity.WebSite.Services
{
    public class CityHallDataService
    {
        private readonly ILogger<CityHallDataService> _logger;
        // Constructor
        public CityHallDataService(ILogger<CityHallDataService> logger)
        {
            _logger = logger;
        }
        public async IAsyncEnumerable<CityHallPublication> GetPosts()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync("http://www.sdolivramento.com.br/prefeitura/index.php?page=todas_noticias.php");
            
            // Debug
            //_logger.LogInformation(document.DocumentElement.OuterHtml);

            var postsHtml = document.QuerySelectorAll("main div.row");

            foreach (var item in postsHtml)
            {
                var fonteDataPublicacao = item.QuerySelector("div.col-lg-10 p i").Text();
                
                var dadosPost = item.QuerySelectorAll("div.col-lg-2 a");
                
                // DEBUG
                //_logger.LogInformation("Título: " + dadosPost.ElementAt(1).QuerySelector("img").GetAttribute("title"));
                //_logger.LogInformation("Imagem: " + dadosPost.ElementAt(1).QuerySelector("img").GetAttribute("src"));
                //_logger.LogInformation("Link: " + "http://www.sdolivramento.com.br/prefeitura/" + dadosPost.ElementAt(0).GetAttribute("href"));
                //_logger.LogInformation("Fonte e Data de Publicação: " + fonteDataPublicacao);

                CityHallPublication publication = new CityHallPublication();
                publication.Title = dadosPost.ElementAt(1).QuerySelector("img").GetAttribute("title");
                publication.LinkImg = dadosPost.ElementAt(1).QuerySelector("img").GetAttribute("src");
                publication.FonteDataPublicacao = fonteDataPublicacao;
                publication.Link = "http://www.sdolivramento.com.br/prefeitura/" + dadosPost.ElementAt(0).GetAttribute("href");
                
                yield return publication;
            }
        }
    }
}
