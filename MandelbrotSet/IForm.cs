using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public interface IForm
    {
        Bitmap MandelbrotSet { set; }
        long CalculationTime { set; }
        double Width { set; }
        double Height { set; }
    }
}
