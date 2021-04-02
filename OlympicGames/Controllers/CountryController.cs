using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class CountryController : Controller
    {
        private CountryContext context;

        public CountryController(CountryContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("CountryList", "Detail");

        }

        [Route("[controller]s/{id?}")]
        public IActionResult CountryList(string id = "All")
        {

            var sports = context.Sports
                .OrderBy(s => s.SportID).ToList();

            var games = context.Games
                .OrderBy(g => g.GameID).ToList();

            List<Country> countries;
            if (id == "All")
            {
                countries = context.Countries
                    .OrderBy(c => c.CountryID).ToList();
            }
            else
            {
                countries = context.Countries
                    .Where(c => c.Sport.SportName == id)
                    .OrderBy(c => c.CountryID).ToList();
            }

            var model = new CountryListViewModel
            {

                Sports = sports,
                Games = games,
                Countries = countries,
                SelectedCountry = id


            };

            return View(model);


        }
    }
}
