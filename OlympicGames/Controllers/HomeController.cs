using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OlympicGames.Models;
using System.Linq;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;
        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }
        public ViewResult Index(string activeSport = "all",string activeGame = "all")
        {
            ViewBag.ActiveSport = activeSport;
            ViewBag.ActiveGame = activeGame;

            List<Game> games = context.Games.ToList();
            List<Sport> sports = context.Sports.ToList();

            sports.Insert(0, new Sport { SportID = "all", SportName = "ALL" });
            games.Insert(0, new Game { GameID = "all", GName = "ALL" });

            //store lists in view bag
            ViewBag.Sports = sports;
            ViewBag.Games = games;

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == activeSport.ToLower());

            var countries = query.ToList();

            return View(countries);
        }
    }
}
