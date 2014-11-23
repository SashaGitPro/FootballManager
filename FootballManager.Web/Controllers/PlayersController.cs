using SoftServe.FootballManager.DAL.Contracts;

namespace SoftServe.FootballManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SoftServe.FootballManager.DAL.Models;

    [Authorize]
    public class PlayersController : Controller
    {
         /// <summary>
        /// unit of work.
        /// </summary>
        private readonly IFootballManagerUnitOfWork unitOfWork;
        
        public PlayersController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWork = unitOfWorkFactory.CreateFootballManagerUnitOfWork();
        }

        //
        // GET: /Players/
        [AllowAnonymous]
        public ViewResult Index(string searchString)
        {
            int age;
            bool isNubmer = int.TryParse(searchString, out age);
            List<Player> players = unitOfWork.Players.FindAll().Include(p => p.Club).ToList();
            if (!String.IsNullOrEmpty(searchString) && isNubmer)
            {
                players = unitOfWork.Players.FindWhere(p => p.Number == age).ToList();
            }
            return View(players);     
        }

        //
        // GET: /Players/Details/5
        
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            Player player = unitOfWork.Players.FindWhere(x => x.Id == id).Single();
            return View(player);
        }

        //
        // GET: /Players/Create

        public ActionResult Create()
        {
            ViewBag.PossibleClubs = unitOfWork.Clubs.FindAll();
            return View();
        } 

        //
        // POST: /Players/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Players.Add(player);
                unitOfWork.Commit();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleClubs = unitOfWork.Clubs.FindAll();
            return View(player);
        }
        
        //
        // GET: /Players/Edit/5
 
        public ActionResult Edit(int id)
        {
            Player player = unitOfWork.Players.FindWhere(x => x.Id == id).Single();
            ViewBag.PossibleClubs = unitOfWork.Clubs.FindAll();
            return View(player);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Players.Update(player);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PossibleClubs = unitOfWork.Clubs.FindAll();
            return View(player);
        }

        //
        // GET: /Players/Delete/5
 
        public ActionResult Delete(int id)
        {
            Player player = unitOfWork.Players.FindWhere(x => x.Id == id).Single();
            return View(player);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = unitOfWork.Players.FindWhere(x => x.Id == id).Single();
            unitOfWork.Players.Remove(player);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Browse(string club)
        {
            // Retrieve Club and its Associated Players from database
            var clubModel = unitOfWork.Clubs.FindAll().Include("Players").Single(c => c.Name == club);

            return View(clubModel);
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ClubsMenu()
        {
            var clubs = unitOfWork.Clubs.FindAll().ToList();

            clubs = clubs.OrderBy(c => c.Name).ToList();

            return PartialView(clubs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}