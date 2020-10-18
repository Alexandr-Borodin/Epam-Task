using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public interface IFigureValidator
    {
        bool IsCanCreateFigure(params Point[] vertices);
    }
}