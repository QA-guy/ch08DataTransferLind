using System.Collections.Generic;

namespace OlympicGames.Models
{
    public class CountryListViewModel
    {
        
        public List<Country> Countries { get; set; }
        public List<Sport> Sports { get; set; }
        public List<Game> Games { get; set; }

        public string SelectedCountry { get; set; }
        public string CheckActiveCountry(string country) =>
            country == SelectedCountry ? "active" : "";


    }
}
