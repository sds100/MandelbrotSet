using System;
using System.Drawing;

namespace MandelbrotSet.MainForm
{
    public interface IPresenter
    {
        void DrawImageAsync(Size bitmapSize, ImageInfo imageInfo, bool saveToHistory);
        void DrawInitialImage(Size bitmapSize);
        void ZoomToSelectedArea(Size bitmapSize, Size rectangleSize, Point cursorLocation);
        void ShowPreviousPlane(Size bitmapSize);
        void Resize(Size newBitmapSize);

        Size CurrentBitmapSize { set;  get; }
    }
}
