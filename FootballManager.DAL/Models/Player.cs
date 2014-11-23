// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Player class.
    /// </summary>
    [Table("Player")]
    public partial class Player
    {
        /// <summary>
        /// Gets or sets Player id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets born country.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string BornCountry { get; set; }

        /// <summary>
        /// Gets or sets age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets main position.
        /// </summary>
        [Required]
        [StringLength(60)]
        public string MainPosition { get; set; }

        /// <summary>
        /// Gets or sets number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets club id.
        /// </summary>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets navigation property club.
        /// </summary>
        public virtual Club Club { get; set; }
    }
}
