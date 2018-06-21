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
        IProgressBar ProgressBar { get; }
        Bitmap MandelbrotSet { set; }
        long CalculationTime { set; }
        double AxisWidth { set; }
        double AxisHeight { set; }

        void OnImageChange(ImageInfo imageInfo);
    }
}
