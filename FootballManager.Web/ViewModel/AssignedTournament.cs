using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftServe.FootballManager.Web.ViewModel
{
    public class AssignedTournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}