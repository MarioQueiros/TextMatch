using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextMatch.Models;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Returns the action result.</returns>
        public ActionResult Index()
        {
            return View( new HomeViewModel() );
        }

        /// <summary>
        /// Indexes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>Returns the action result.</returns>
        /// <exception cref="System.ArgumentNullException">viewModel</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( HomeViewModel viewModel )
        {
            // Validates if the view model is null or if each one of the view model properties are also null or empty
            if ( viewModel == null || string.IsNullOrEmpty( viewModel.Text ) || string.IsNullOrEmpty( viewModel.SubText ) )
            {
                throw new ArgumentNullException( "viewModel" );
            }

            if ( ModelState.IsValid )
            {
                viewModel.Positions = this.GetPositions( viewModel.Text, viewModel.SubText );
            }

            return View( viewModel );
        }

        /// <summary>
        /// Gets the positions.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="subText">The sub text.</param>
        /// <returns>Retuns the matched positions.</returns>
        public string GetPositions( string text, string subText )
        {
            var positions = string.Empty;

            // Validates if the sub text is different than empty or if the sub text length is lower than the text length
            if ( subText.Length != 0 && text.Length >= subText.Length )
            {
                for ( int i = 0; i < text.Length; i++ )
                {
                    var pos = i;
                    var found = true;

                    for ( int j = 0; j < subText.Length; j++ )
                    {
                        // Compares the current text position to the sub text position
                        // If false the cycle is broken to stop the search
                        if ( j >= text.Length || char.ToLower( text[ i + j ], CultureInfo.InvariantCulture ) != char.ToLower( subText[ j ], CultureInfo.InvariantCulture ) )
                        {
                            found = false;
                            break;
                        }
                    }

                    // If there was found a position is saved into positions property.
                    // And also the current text position is set to the last position of the matched sub text position, 
                    // because there is no need to validate again length of sub text on text
                    if ( found )
                    {
                        i += subText.Length - 1;

                        positions = positions.Length == 0 ? ( pos + 1 ).ToString( CultureInfo.InvariantCulture ) : string.Format( "{0}, {1}", positions, ( pos + 1 ).ToString( CultureInfo.InvariantCulture ) );
                    }
                }
            }

            return string.IsNullOrEmpty( positions ) ? "There is no output" : positions;
        }
    }
}