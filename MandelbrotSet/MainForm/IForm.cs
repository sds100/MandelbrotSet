using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet.MainForm
{
    public interface IForm
    {
        Bitmap MandelbrotSet { set; }
        long CalculationTime { set; }
        double AxisWidth { set; }
        double AxisHeight { set; }
    }
}
