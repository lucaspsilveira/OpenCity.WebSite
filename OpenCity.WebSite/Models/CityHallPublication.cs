using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenCity.WebSite.Models
{
    public class CityHallPublication
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string FonteDataPublicacao { get; set; }
        public string LinkImg { get; set; }


        public override string ToString() => JsonSerializer.Serialize<CityHallPublication>(this);
    }
}
