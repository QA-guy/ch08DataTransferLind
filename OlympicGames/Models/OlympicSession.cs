using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OlympicGames.Models
{
    public class OlympicSession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countkey";
        private const string SportKey = "sport";
        private const string GameKey = "game";

        private ISession session { get; set; }
        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);           
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        public int GetMyCountryCount() => session.GetInt32(CountKey) ?? 0;

        public void SetActiveSport(string activeSport) =>
            session.SetString(SportKey, activeSport);
        public string GetActiveSport() => session.GetString(SportKey);

        public void SetActiveGame(string activeGame) =>
            session.SetString(GameKey, activeGame);
        public string GetActiveGame() => session.GetString(GameKey);

        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }

    }
}
