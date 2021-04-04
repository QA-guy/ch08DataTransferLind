using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveSport { get; set; } = "all";
        public string ActiveGame { get; set; } = "all";
    }
}
