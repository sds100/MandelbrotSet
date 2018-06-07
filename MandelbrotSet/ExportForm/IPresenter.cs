using System.Drawing;

namespace MandelbrotSet.ExportForm
{
    interface IPresenter
    {
        void ShowPreview(Bitmap bitmap);
        void UseCurrentOptions();
        void Export();
    }
}
