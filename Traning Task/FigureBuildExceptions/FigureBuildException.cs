using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureBuildExceptions
{
    public class FigureBuildException : Exception
    {
        public FigureBuildException(string message) : base(message) { }
    }
}
