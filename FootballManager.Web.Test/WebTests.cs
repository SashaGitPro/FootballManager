﻿namespace SoftServe.FootballManager.Web.Test
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
        public void TestSearchString()
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
    }
}
