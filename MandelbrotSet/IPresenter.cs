using System.Drawing;

namespace MandelbrotSet
{
    interface IPresenter
    {
        void DrawInitialMandelbrotSet(Size bitmapSize);
        void ZoomToSelectedArea(Size bitmapSize, Size rectangleSize, Point cursorLocation);
        void ShowPreviousPlane(Size bitmapSize);
        void Resize(Size newBitmapSize);
    }
}
