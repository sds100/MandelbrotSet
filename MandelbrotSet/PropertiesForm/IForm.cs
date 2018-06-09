using System;
using System.Drawing;

namespace MandelbrotSet.PropertiesForm
{
    public interface IForm
    {
        Size BitmapSize { get; }
        double Magnification { get; set; }
        PointD FocusPoint { get; set; }
        String FileName { get; }
        String Directory { get; }

        bool AreOptionsValid();
    }
}
