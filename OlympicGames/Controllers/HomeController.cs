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
        public ViewResult Index(string activeSport = "all",string activeGame = "all")
        {
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

        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            Utility.LogCountryClick(model.Country.CountryID);

            TempData["ActiveSport"] = model.ActiveSport;
            TempData["ActiveGame"] = model.ActiveGame;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Sport)
                    .FirstOrDefault(c => c.CountryID == id),
                ActiveSport = TempData.Peek("ActiveSport").ToString() ,
                ActiveGame = TempData.Peek("ActiveGame").ToString() 
            };
            return View(model);
        }
    }
}
