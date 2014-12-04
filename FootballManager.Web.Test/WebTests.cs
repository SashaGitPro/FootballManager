namespace SoftServe.FootballManager.Web.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftServe.FootballManager.DAL.Services;
    using SoftServe.FootballManager.DAL.Models;
    using System.Linq;
    using System.Collections.Generic;
    using Moq;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.Web.Test.ObjectMothers;
    using SoftServe.FootballManager.Web.Test.Comparers;

    /// <summary>
    /// Test class for web project.
    /// </summary>
    [TestClass]
    public class WebTests
    {

        /// <summary>
        /// Test search string.
        /// </summary>
        [TestMethod]
        public void SearchString_Number7ToSearch_ReturnsPlayerWithNumber7()
        {
            Player p = new Player()
            {
                Id = 1,
                Name = "Cristiano Ronaldo",
                Number = 7
            };

            var searchString = "7";
            List<Player> players = new List<Player>();
            players.Add(p);
            var player = players.Single(s => s.Number == Convert.ToInt32(searchString));
            Assert.AreEqual(player.Number, Convert.ToInt32(searchString));
        }

        [TestMethod]
        public void FindPlayerById()
        {
            Mock<IRepository<Player>> mock = new Mock<IRepository<Player>>();
            mock.Setup(m => (Player)m.FindWhere(p => p.Id == 5)).Returns(new Player { Id = 5 });
            IRepository<Player> repository = mock.Object;
            var player = (Player)repository.FindWhere(p => p.Id == 5);
            Assert.IsTrue(player.Id == 5);
        }

        [TestMethod]
        public void FindAll_TournamentsExist_AllTournamentsReturned()
        {
            var repositoryMock = new Mock<IRepository<Tournament>>();
            repositoryMock.Setup(r => r.FindAll())
                .Returns(TournamentObjectMother.CreateTournaments().AsQueryable());
           
            IRepository<Tournament> tournamentRepository = repositoryMock.Object;
            
            var expectedTournaments = new List<Tournament>(
             TournamentObjectMother.CreateTournaments().ToList());
            var actualTournaments = tournamentRepository.FindAll().ToList();

            CollectionAssert.AreEqual(expectedTournaments, actualTournaments, new TournamentComparer());
        }

        [TestMethod]
        public void Add_NewTournament_TournamentAdded()
        {
            var repositoryMock = new Mock<IRepository<Tournament>>();
            Tournament t = new Tournament { Id=1, Name="Tournament 1"};
            List<Tournament> tournaments = new List<Tournament>();
            repositoryMock.Setup(r => r.Add(It.IsAny<Tournament>()))
                .Callback((Tournament tournament) =>
            {
                tournaments.Add(tournament);
            });

            IRepository<Tournament> tournamentRepository = repositoryMock.Object;
            tournamentRepository.Add(t);

            CollectionAssert.Contains(tournaments, t);
        }

        [TestMethod]
        public void Remove_ExistingTournament_TournamentRemoved()
        {
            var repositoryMock = new Mock<IRepository<Tournament>>();
            Tournament t = new Tournament { Id = 1, Name = "Tournament 1" };
            List<Tournament> tournaments = new List<Tournament>();
            repositoryMock.Setup(r => r.Remove(It.IsAny<Tournament>()))
                .Callback((Tournament tournament) =>
                {
                    tournaments.Remove(tournament);
                });

            IRepository<Tournament> tournamentRepository = repositoryMock.Object;

            tournaments.Add(t);
            tournamentRepository.Remove(t);

            CollectionAssert.DoesNotContain(tournaments, t);
        }

        [TestMethod]
        public void Update_NewDataForExistingTournament_TournamentDataChanged()
        {
            var repositoryMock = new Mock<IRepository<Tournament>>();
            Tournament oldTournament = new Tournament { Id = 1, Name = "Tournament 1" };
            Tournament expectedTournament = new Tournament { Id = 2, Name = "Tournament" };
            List<Tournament> tournaments = new List<Tournament>();
            repositoryMock.Setup(r => r.Update(It.IsAny<Tournament>()))
                .Callback((Tournament tournament) =>
                {
                    oldTournament.Id = tournament.Id;
                    oldTournament.Name = tournament.Name;
                });

            IRepository<Tournament> tournamentRepository = repositoryMock.Object;

            tournamentRepository.Update(expectedTournament);

            Assert.AreEqual(oldTournament.Id, expectedTournament.Id);
        }
    }
}
