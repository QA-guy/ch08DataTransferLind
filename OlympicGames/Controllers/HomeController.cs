using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OlympicGames.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;
        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }
        public ViewResult Index(string activeSport = "all", string activeGame = "all")
        {
            //New changes-pg.339.  Updates for Chapter 9 for session states
            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);

            var data = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    c => c.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(c =>
                   c.Sport.SportID.ToLower() == activeSport.ToLower());
            data.Countries = query.ToList();

            return View(data);
        }

        //[HttpPost]
        //public RedirectToActionResult Details(CountryViewModel model)
        //{
        //    Utility.LogCountryClick(model.Country.CountryID);

        //    TempData["ActiveSport"] = model.ActiveSport;
        //    TempData["ActiveGame"] = model.ActiveGame;
        //    return RedirectToAction("Details", new { ID = model.Country.CountryID });
        //}
        [HttpPost]
        public ActionResult Details(CountryListViewModel model, string command)
        {
            model.Country = model.Countries.FirstOrDefault(i => i.CountryID == command);

            TempData["ActiveSport"] = model.ActiveSport;
            TempData["ActiveGame"] = model.ActiveGame;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Sport)
                    .FirstOrDefault(c => c.CountryID == id),
                //ActiveSport = TempData.Peek("ActiveSport").ToString() ,
                //ActiveGame = TempData.Peek("ActiveGame").ToString()
                ActiveSport = session.GetActiveSport(),
                ActiveGame = session.GetActiveGame()

            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(c => c.Sport)
                .Include(c => c.Game)
                .Where(c => c.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new OlympicSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveSport = session.GetActiveSport(),
                    ActiveGame = session.GetActiveGame()

                });
        }
    }
}
