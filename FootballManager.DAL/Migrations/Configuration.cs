namespace SoftServe.FootballManager.DAL.Migrations
{
    using SoftServe.FootballManager.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftServe.FootballManager.DAL.Models.FootballManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SoftServe.FootballManager.DAL.Models.FootballManagerContext";
        }

        protected override void Seed(SoftServe.FootballManager.DAL.Models.FootballManagerContext context)
        {
            context.Tournaments.AddOrUpdate(
                   new Tournament()
                   {
                       TournamentId = 1,
                       Name = "LFP"
                   },
                   new Tournament()
                   {
                       TournamentId = 2,
                       Name = "Spain Cup"
                   }
               );
            context.SaveChanges();

            context.Clubs.AddOrUpdate(
                new Club()
                {
                    ClubId = 1,
                    Name = "Read Madrid",
                    Coach = "Carlo Ancelotti",
                    Owner = "Florentino Peres",
                    Country = "Spain"
                },
                new Club
                {
                    ClubId = 2,
                    Name = "Barcelona",
                    Coach = "Louis Enrique",
                    Owner = "Joseph Bartomeu",
                    Country = "Spain"
                }
            );

            context.SaveChanges();

            context.Players.AddOrUpdate(
                new Player()
                {
                    PlayerId = 1,
                    FootballClubId = 1,
                    Name = "Carim Benzema",
                    Born = new DateTime(1987, 12, 19),
                    BornCountry = "France",
                    MainPosition = "Forward",
                    Number = 9
                },
                new Player()
                {
                    PlayerId = 2,
                    FootballClubId = 2,
                    Name = "Cristiano Ronaldo",
                    Born = new DateTime(1985, 2, 5),
                    BornCountry = "Portugal",
                    MainPosition = "Forward",
                    Number = 7
                }
            );
            context.SaveChanges();
        }
    }
}
