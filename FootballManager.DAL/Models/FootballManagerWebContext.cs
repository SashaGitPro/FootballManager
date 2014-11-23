using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoftServe.FootballManager.DAL.Models
{
    public class FootballManagerWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SoftServe.FootballManager.Web.Models.FootballManagerWebContext>());

        public DbSet<SoftServe.FootballManager.DAL.Models.Club> Clubs { get; set; }

        public DbSet<SoftServe.FootballManager.DAL.Models.Player> Players { get; set; }

        public DbSet<SoftServe.FootballManager.DAL.Models.Tournament> Tournaments { get; set; }
    }
}