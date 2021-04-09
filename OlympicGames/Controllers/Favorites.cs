using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace OlympicGames.Controllers
{
    public class Favorites : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveSport = session.GetActiveSport(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite teams cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveSport = session.GetActiveSport(),
                    ActiveGame = session.GetActiveGame()
                });
        }
    }
}
