using System;
using System.Drawing;

namespace MandelbrotSet.ExportForm
{
    public interface IForm
    {
        Size BitmapSize { get; set; }
        long Magnification { get; set; }
        PointD FocusPoint { get; set; }
        String FileName { get; }
        String Directory { get; }
        Bitmap Preview { set; }
    }
}
