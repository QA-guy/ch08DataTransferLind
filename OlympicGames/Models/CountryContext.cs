using Microsoft.EntityFrameworkCore;


namespace OlympicGames.Models
{
    public class CountryContext:DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "win", GName = "Winter Olympics" },
                new Game { GameID = "sum", GName = "Summer Olympics" },
                new Game { GameID = "par", GName = "Paralympics" },
                new Game { GameID = "you",GName = "Youth Olympic Games" });

            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportID = "cin", SportName = "Curling", SportType = "Indoor"},
                new Sport { SportID = "bou", SportName = "Bobsleigh", SportType = "Outdoor"},
                new Sport { SportID = "din", SportName = "Diving", SportType = "Indoor"},
                new Sport { SportID = "rou",SportName = "Road Cycling", SportType = "Outdoor" },
                new Sport { SportID = "ain", SportName = "Archery", SportType = "Indoor"},
                new Sport { SportID = "cou", SportName = "Canoe Sprint", SportType = "Outdoor"},
                new Sport { SportID = "bin", SportName = "Breakdancing", SportType = "Indoor"},
                new Sport { SportID = "sou", SportName = "Skateboarding", SportType = "Outdoor"}
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "aus", Name = "Austria", SportID = "cou", GameID = "par", CountryImage = "Austria.PNG" },
                new Country { CountryID = "bra", Name = "Brazil", SportID = "rou", GameID = "sum", CountryImage = "Brazil.PNG" },
                new Country { CountryID = "can", Name = "Canada", SportID = "cin", GameID = "win", CountryImage = "Canada.PNG" },
                new Country { CountryID = "chi", Name = "China", SportID = "din", GameID = "sum", CountryImage = "China.PNG" },
                new Country { CountryID = "cyp", Name = "Cyprus", SportID = "bin", GameID = "you", CountryImage = "Cyprus.PNG" },
                new Country { CountryID = "fin", Name = "Finland", SportID = "cou", GameID = "par", CountryImage = "Finland.PNG" },
                new Country { CountryID = "fra", Name = "France", SportID = "bin", GameID = "you", CountryImage = "France.PNG" },
                new Country { CountryID = "ger", Name = "Germany", SportID = "din", GameID = "sum", CountryImage = "Germany.PNG" },
                new Country { CountryID = "gre", Name = "GreatBritain", SportID = "cin", GameID = "win", CountryImage = "GreatBritain.PNG" },
                new Country { CountryID = "ita", Name = "Italy", SportID = "bou", GameID = "win", CountryImage = "Italy.PNG" },
                new Country { CountryID = "jam", Name = "Jamaica", SportID = "bou", GameID = "win", CountryImage = "Jamaica.PNG" },
                new Country { CountryID = "jap", Name = "Japan", SportID = "bou", GameID = "win", CountryImage = "Japan.PNG" },
                new Country { CountryID = "mex", Name = "Mexico", SportID = "din", GameID = "sum", CountryImage = "Mexico.PNG" },
                new Country { CountryID = "net", Name = "Netherlands", SportID = "rou", GameID = "sum", CountryImage = "Netherlands.PNG" },
                new Country { CountryID = "pak", Name = "Pakistan", SportID = "cou", GameID = "par", CountryImage = "Pakistan.PNG" },
                new Country { CountryID = "por", Name = "Portugal", SportID = "sou", GameID = "you", CountryImage = "Portugal.PNG" },
                new Country { CountryID = "rus", Name = "Russia", SportID = "bin", GameID = "you", CountryImage = "Russia.PNG" },
                new Country { CountryID = "slo", Name = "Slovakia", SportID = "sou", GameID = "you", CountryImage = "Slovakia.PNG" },
                new Country { CountryID = "swe", Name = "Sweden", SportID = "cin", GameID = "win", CountryImage = "Sweden.PNG" },
                new Country { CountryID = "tha", Name = "Thailand", SportID = "ain", GameID = "par", CountryImage = "Thailand.PNG" },
                new Country { CountryID = "ukr", Name = "Ukraine", SportID = "ain", GameID = "par", CountryImage = "Ukraine.PNG" },
                new Country { CountryID = "ura", Name = "Uraguay", SportID = "ain", GameID = "par", CountryImage = "Uraguay.PNG" },
                new Country { CountryID = "usa", Name = "USA", SportID = "rou", GameID = "sum", CountryImage = "USA.PNG" },
                new Country { CountryID = "zim", Name = "Zimbabwe", SportID = "cou", GameID = "par", CountryImage = "Zimbabwe.PNG" }
                );
        }

    }
}
