namespace SoftServe.FootballManager.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.DAL.Models;

    public class HomeController : Controller
    {
        private readonly IFootballManagerUnitOfWork unitOfWork;
        
        public HomeController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWork = unitOfWorkFactory.CreateFootballManagerUnitOfWork();
        }

        public ActionResult Index()
        {
            var players = unitOfWork.Players.FindAll().Include(p=>p.Club).ToList();
            return View(players);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
