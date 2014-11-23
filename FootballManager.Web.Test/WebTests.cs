namespace SoftServe.FootballManager.Web.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftServe.FootballManager.DAL.Services;
    using SoftServe.FootballManager.DAL.Models;
    using System.Linq;
    using System.Collections.Generic;

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
    }
}
