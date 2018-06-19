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
        String Folder { get; set; }
        IExportImage iExportImage { get; }

        bool AreOptionsValid();
    }
}
