using System.Drawing;

namespace MandelbrotSet.MainForm
{
    public interface IForm
    {
        Bitmap MandelbrotSet { set; }
        long CalculationTime { set; }
        double AxisWidth { set; }
        double AxisHeight { set; }
        
        void OnRenderStart();
        void OnRenderFinish();

        /// <summary>
        /// Executed when the image being shown to the user changes.
        /// </summary>
        /// <param name="imageInfo">The <see cref="ImageInfo"/> of the new image</param>
        void OnImageChange(ImageInfo imageInfo);
    }
}
