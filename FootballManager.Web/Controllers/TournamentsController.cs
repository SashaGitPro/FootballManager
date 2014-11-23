
using System.Data;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace SoftServe.FootballManager.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.DAL.Models;
    using System.Collections.Generic;
    using SoftServe.FootballManager.Web.ViewModel;
   
    /// <summary>
    /// Tournament controller.
    /// </summary>
    [Authorize]
    public class TournamentsController : Controller
    {
        /// <summary>
        /// unit of work.
        /// </summary>
        private readonly IFootballManagerUnitOfWork unitOfWork;
        
        public TournamentsController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWork = unitOfWorkFactory.CreateFootballManagerUnitOfWork();
        }
        // GET: /Tournaments/

        [AllowAnonymous]     
        public ViewResult Index()
        {
            var tournaments = unitOfWork.Tournaments.FindAll().Include(t => t.Clubs).ToList();
            return View(tournaments);
        }

        //
        // GET: /Tournaments/Details/5

        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            Tournament tournament = unitOfWork.Tournaments.FindWhere(x => x.Id == id).Single();
            return View(tournament);
        }

        //
        // GET: /Tournaments/Create

        public ActionResult Create()
        {
            PopulateAssignedClubs();
            return View();
        } 

        //
        // POST: /Tournaments/Create

        [HttpPost]
        public ActionResult Create(Tournament tournament, string[] selectedClubs)
        {
            if (TryUpdateModel(tournament, "",
                 new string[] { "Name", "Tournaments" }))
            {
                try
                {
                    UpdateTournamentClubs(selectedClubs, tournament);

                    unitOfWork.Tournaments.Add(tournament);
                    unitOfWork.Commit();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateAssignedClubs(tournament);       
            return View(tournament);
        }
        
        //
        // GET: /Tournaments/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tournament tournament = unitOfWork.Tournaments.FindWhere(x => x.Id == id).Single();
            PopulateAssignedClubs();
            return View(tournament);
        }

        //
        // POST: /Tournaments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedClubs)
        {
            Tournament tournament = unitOfWork.Tournaments.FindWhere(x => x.Id == id).Single();
            if (TryUpdateModel(tournament, "",
               new string[] { "Name", "Tournaments" }))
            {
                try
                {
                    UpdateTournamentClubs(selectedClubs, tournament);

                    unitOfWork.Tournaments.Update(tournament);
                    unitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateAssignedClubs(tournament);
            return View(tournament);
        }

        //
        // GET: /Tournaments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tournament tournament = unitOfWork.Tournaments.FindWhere(x => x.Id == id).Single();
            return View(tournament);
        }

        //
        // POST: /Tournaments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = unitOfWork.Tournaments.FindWhere(x => x.Id == id).Single();
            unitOfWork.Tournaments.Remove(tournament);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        private void UpdateTournamentClubs(string[] selectedClubs, Tournament tournament)
        {
            if (selectedClubs == null)
            {
                tournament.Clubs.Clear();
                return;
            }

            var selectedClubsHS = new HashSet<string>(selectedClubs);
            var tournamentClubs = new HashSet<int>
                (tournament.Clubs.Select(t => t.Id));
            foreach (var club in unitOfWork.Clubs.FindAll())
            {
                if (selectedClubsHS.Contains(club.Id.ToString()))
                {
                    if (!tournamentClubs.Contains(club.Id))
                    {
                        club.Tournaments.Add(tournament);
                    }
                }
                else
                {
                    if (tournamentClubs.Contains(club.Id))
                    {
                        tournament.Clubs.Remove(club);
                    }
                }
            }
        }

        private void PopulateAssignedClubs()
        {
            var allClubs = unitOfWork.Clubs.FindAll().ToList();
            var viewModel = new List<AssignedClub>();

            foreach (var club in allClubs)
            {
                viewModel.Add(new AssignedClub
                {
                    Id = club.Id,
                    Name = club.Name,
                    Assigned = false
                });
            }

            ViewBag.PossibleClubs = viewModel;
        }

        private void PopulateAssignedClubs(Tournament tournament)
        {
            var allClubs = unitOfWork.Clubs.FindAll().ToList();
            var tournamentClubs = new HashSet<int>(tournament.Clubs.Select(t => t.Id));
            var viewModel = new List<AssignedClub>();

            foreach (var club in allClubs)
            {
                viewModel.Add(new AssignedClub
                {
                    Id = club.Id,
                    Name = club.Name,
                    Assigned = tournamentClubs.Contains(club.Id)
                });
            }

            ViewBag.PossibleClubs = viewModel;
        }
    }
}