using System.ComponentModel.DataAnnotations;

namespace TextMatch.Models
{
    public class HomeViewModel
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [Required( ErrorMessage = "Required" )]
        [MinLength( 1 )]
        [MaxLength( 250 )]
        public string Text
        { get; set; }

        /// <summary>
        /// Gets or sets the sub text.
        /// </summary>
        /// <value>
        /// The sub text.
        /// </value>
        [Required( ErrorMessage = "Required" )]
        [MinLength( 1 )]
        [MaxLength( 250 )]
        public string SubText
        { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>
        /// The positions.
        /// </value>
        public string Positions
        { get; set; }
    }
}