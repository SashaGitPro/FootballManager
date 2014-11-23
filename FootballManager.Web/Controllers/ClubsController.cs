// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClubsController.cs" company="SoftServe">
//   
// </copyright>
// <summary>
//   Defines the ClubsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;

namespace SoftServe.FootballManager.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.DAL.Models;
    using System.Data;
    using System.Collections.Generic;
    using SoftServe.FootballManager.Web.ViewModel;

    /// <summary>
    /// Clubs controller class.
    /// </summary>
    [Authorize]
    public class ClubsController : Controller
    {
        /// <summary>
        /// unit of work.
        /// </summary>
        private readonly IFootballManagerUnitOfWork unitOfWork;

        public ClubsController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWork = unitOfWorkFactory.CreateFootballManagerUnitOfWork();
        }

        // GET: /Clubs/

        /// <summary>
        /// Index page for clubs.
        /// </summary>
        /// <returns>View for index</returns>
        [AllowAnonymous]
        public ViewResult Index()
        {
            var clubs = this.unitOfWork.Clubs.FindAll().Include(a => a.Tournaments).Include(c => c.Players).ToList();
            return this.View(clubs);
        }

        //
        // GET: /Clubs/Details/5

        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            Club club = unitOfWork.Clubs.FindWhere(x => x.Id == id).Single();
            return View(club);
        }

        //
        // GET: /Clubs/Create

        public ActionResult Create()
        {
            PopulateAssignedTournaments();
            return View();
        }

        //
        // POST: /Clubs/Create

        [HttpPost]
        public ActionResult Create(Club club, string[] selectedTournaments)
        {
            if (TryUpdateModel(club, "",
               new string[] { "Name", "Clubs" }))
            {
                try
                {
                    UpdateClubTournaments(selectedTournaments, club);

                    unitOfWork.Clubs.Add(club);
                    unitOfWork.Commit();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateAssignedTournaments(club);
            return View(club);
        }

        //
        // GET: /Clubs/Edit/5

        public ActionResult Edit(int id)
        {
            Club club = unitOfWork.Clubs.FindWhere(x => x.Id == id).Single();
            PopulateAssignedTournaments(club);
            return View(club);
        }

        //
        // POST: /Clubs/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedTournaments)
        {
            Club club = unitOfWork.Clubs.FindWhere(x => x.Id == id).Single();
            if (TryUpdateModel(club, "",
               new string[] { "Name", "Clubs" }))
            {
                try
                {
                    UpdateClubTournaments(selectedTournaments, club);

                    unitOfWork.Clubs.Update(club);
                    unitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateAssignedTournaments(club);
            return View(club);
        }

        //
        // GET: /Clubs/Delete/5

        public ActionResult Delete(int id)
        {
            Club club = unitOfWork.Clubs.FindWhere(x => x.Id == id).Single();
            return View(club);
        }

        //
        // POST: /Clubs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = unitOfWork.Clubs.FindWhere(x => x.Id == id).Single();
            unitOfWork.Clubs.Remove(club);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private void UpdateClubTournaments(string[] selectedTournaments, Club club)
        {
            if (selectedTournaments == null)
            {
                club.Tournaments.Clear();
                return;
            }

            var selectedTournamentsHS = new HashSet<string>(selectedTournaments);
            var clubTournaments = new HashSet<int>
                (club.Tournaments.Select(t => t.Id));
            foreach (var tournament in unitOfWork.Tournaments.FindAll())
            {
                if (selectedTournamentsHS.Contains(tournament.Id.ToString()))
                {
                    if (!clubTournaments.Contains(tournament.Id))
                    {
                        club.Tournaments.Add(tournament);
                    }
                }
                else
                {
                    if (clubTournaments.Contains(tournament.Id))
                    {
                        club.Tournaments.Remove(tournament);
                    }
                }
            }
        }

        private void PopulateAssignedTournaments()
        {
            var allTournaments = unitOfWork.Tournaments.FindAll().ToList();
            var viewModel = new List<AssignedTournament>();

            foreach (var tournament in allTournaments)
            {
                viewModel.Add(new AssignedTournament
                {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    Assigned = false
                });
            }

            ViewBag.PossibleTournaments = viewModel;
        }

        private void PopulateAssignedTournaments(Club club)
        {
            var allTournaments = unitOfWork.Tournaments.FindAll().ToList();
            var clubTournaments = new HashSet<int>(club.Tournaments.Select(t => t.Id));
            var viewModel = new List<AssignedTournament>();

            foreach (var tournament in allTournaments)
            {
                viewModel.Add(new AssignedTournament
                {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    Assigned = clubTournaments.Contains(tournament.Id)
                });
            }

            ViewBag.PossibleTournaments = viewModel;
        }
    }
}