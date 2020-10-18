using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureBuildExceptions
{
    /// <summary>
    /// Describes figure build exception
    /// </summary>
    public class FigureBuildException : Exception
    {
        /// <summary>
        /// Constructor of figure build exception.
        /// </summary>
        /// <param name="message">Message to show cause of exception.</param>
        public FigureBuildException(string message) : base(message) { }
    }
}
