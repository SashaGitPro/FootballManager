namespace SoftServe.FootballManager.Web.Test.ObjectMothers
{
    using SoftServe.FootballManager.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// TournamentObjectMother class
    /// </summary>
    internal static class TournamentObjectMother
    {
        /// <summary>
        /// Creates Tournaments
        /// </summary>
        /// <returns>IEnumerable tournaments</returns>
        public static IEnumerable<Tournament> CreateTournaments()
        {
            yield return new Tournament
            {
                Id = 1,
                Name = "Tournament 1"
            };
            yield return new Tournament
            {
                Id = 2,
                Name = "Tournament 2"
            };
            yield return new Tournament
            {
                Id = 2,
                Name = "Tournament 2"
            };
        }
    }
}
