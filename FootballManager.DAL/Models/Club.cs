// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Club.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines Entity Framework implementation of the IUnitOfWork contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Club model.
    /// </summary>
    [Table("Club")]
    public partial class Club
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Club"/> class.
        /// </summary>
        public Club()
        {
            this.Players = new HashSet<Player>();
            this.Tournaments = new HashSet<Tournament>();
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets President.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string President { get; set; }

        /// <summary>
        /// Gets or sets Coach.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Coach { get; set; }

        /// <summary>
        /// Gets or sets players.
        /// </summary>
        public virtual ICollection<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets tournaments.
        /// </summary>
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
