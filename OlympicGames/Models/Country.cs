using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    //Country Class
    public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; }
        public string SportID { get; set; }

        public string GameID { get; set; }
        public Game Game {get;set;}
        public Sport Sport { get; set; }

        public string CountryImage { get; set; }
       

    }
}
