using System.Collections.Generic;


namespace OlympicGames.Models
{
    public class CountryListViewModel : CountryViewModel
    {

        public List<Country> Countries { get; set; }
       
        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = value;
                sports.Insert(0,
                    new Sport { SportID = "all", SportName = "All" });
            }
        }


        private List<Game> games ;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = value;
                games.Insert(0,
                    new Game { GameID = "all", GName = "All" });
            }
        }

        //public string SelectedCountry { get; set; }
        //public string CheckActiveCountry(string country) =>
        //    country == SelectedCountry ? "active" : "";
        public string CheckActiveSport(string s) =>
           s.ToLower() == ActiveSport.ToLower() ? "active" : "";

        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";


    }
}
