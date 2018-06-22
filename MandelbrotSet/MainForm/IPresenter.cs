using System.Drawing;

namespace MandelbrotSet.MainForm
{
    public interface IPresenter
    {
        void DrawImageAsync(Size bitmapSize, ImageInfo imageInfo);
        void DrawInitialImage(Size bitmapSize);
        void ZoomToSelectedArea(Size bitmapSize, Size rectangleSize, Point cursorLocation);
        void ShowPreviousPlane(Size bitmapSize);
        void Resize(Size newBitmapSize);
        void SaveImageToHistory(ImageInfo imageInfo);

        Size CurrentBitmapSize { set;  get; }
    }
}
