using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OpenCity.WebSite.Pages
{
    public class SobreModel : PageModel
    {
        private readonly ILogger<SobreModel> _logger;

        public SobreModel(ILogger<SobreModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
