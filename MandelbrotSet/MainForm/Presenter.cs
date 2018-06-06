using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MandelbrotSet.MainForm
{
    /// <summary>
    /// The Presenter for <see cref="MainForm"/>
    /// </summary>
    public class Presenter : IPresenter
    {
        /// <summary>
        /// Gets the lengths of the current axis'.
        /// </summary>
        private AxisLengths CurrentAxisLengths => PlaneHistory.Last().AxisLengths;

        /// <summary>
        /// Gets the current focus point.
        /// </summary>
        private PointD CurrentFocusPoint => PlaneHistory.Last().FocusPoint;

        /// <summary>
        /// Stores instances of <see cref="MandelPlane"/> so previous Mandelbrot Sets can be
        /// recreated
        /// </summary>
        private List<MandelPlane> PlaneHistory { get; }

        /// <summary>
        /// Interface from the <see cref="MainForm"/>.
        /// It is an element of the MVP pattern and used to communicate with the form.
        /// </summary>
        private IForm Form { get; }

        /// <param name="form">Implentation of <see cref="IForm"/> to use to output
        /// Mandelbrot Sets.</param>
        public Presenter(IForm form)
        {
            PlaneHistory = new List<MandelPlane>();
            Form = form;

            //add the inital axislengths and focus-point to history.
            PlaneHistory.Add(new MandelPlane(
                MandelPlane.DEFAULT_AXIS_LENGTHS,
                MandelPlane.DEFAULT_FOCUS_POINT));
        }

        public void DrawInitialMandelbrotSet(Size bitmapSize)
        {
            DrawMandelbrotSetAsync(() => MandelbrotSet.Create(
                bitmapSize,
                new MandelPlane(MandelPlane.DEFAULT_AXIS_LENGTHS,
                                MandelPlane.DEFAULT_FOCUS_POINT)));

            Form.Width = MandelPlane.DEFAULT_AXIS_LENGTHS.X;
            Form.Height = MandelPlane.DEFAULT_AXIS_LENGTHS.Y;
        }

        /// <summary>
        /// Redraw the current Mandelbrot Set with a different size but keep it's visible portion
        /// of the plane the same.
        /// </summary>
        /// <param name="newBitmapSize"> The new size of the Mandelbrot Set</param>
        public void Resize(Size newBitmapSize)
        {
            var plane = PlaneHistory.Last();

            DrawMandelbrotSetAsync(() => MandelbrotSet.Create(
                newBitmapSize,
                plane));

            Form.Width = plane.Width;
            Form.Height = plane.Height;
        }

        /// <summary>
        /// Moves and zooms to the selected part of the plane.
        /// </summary>
        /// <param name="bitmapSize">The size of the image to create</param>
        /// <param name="rectangleSize">The size of the selected area of the current image</param>
        /// <param name="cursorLocation">The location of the cursor on the current image</param>
        public void ZoomToSelectedArea(Size bitmapSize, Size rectangleSize, Point cursorLocation)
        {
            var newAxisLengths = CalculateAxisLengths(bitmapSize, rectangleSize);
            var newFocusPoint = ConvertBitmapPointToGraphPoint(cursorLocation, bitmapSize);

            var plane = new MandelPlane(newAxisLengths, newFocusPoint);
            PlaneHistory.Add(plane);

            DrawMandelbrotSetAsync(() => MandelbrotSet.Create(bitmapSize, plane));

            Form.Width = plane.Width;
            Form.Height = plane.Height;
        }

        /// <summary>
        /// Redraws the previous Mandelbrot Set.
        /// </summary>
        /// <param name="bitmapSize">The size of the image to create</param>
        public void ShowPreviousPlane(Size bitmapSize)
        {
            PlaneHistory.Remove(PlaneHistory.Last());

            var plane = PlaneHistory.Last();
            DrawMandelbrotSetAsync(() => MandelbrotSet.Create(bitmapSize, plane));

            Form.Width = plane.Width;
            Form.Height = plane.Height;
        }
        
        /// <summary>
        /// Create a Mandelbrot Set then show it to the user asynchronously.
        /// </summary>
        /// <param name="func">The function to invoke asynchronously which will return a bitmap
        /// of a Mandelbrot Set</param>
        private async void DrawMandelbrotSetAsync(Func<Bitmap> func)
        {
            /*
             * get the current time which will be used to calculate how long it took to create and
             * then output the MandelbrotSet
            */
            long before = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            await Task.Run(() =>
            {
                var bitmap = func.Invoke();

                if (bitmap != null)
                {
                    Form.MandelbrotSet = bitmap;
                }
            });

            long after = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            //output the time taken to draw a Mandelbrot Set
            Form.CalculationTime = after - before;
        }


        /// <summary>
        /// Converts a point on a Bitmap to it's equivalent on the current portion of the complex
        /// plane
        /// </summary>
        /// <param name="bitmapPoint">The point to convert</param>
        /// <param name="bitmapSize">The size of the bitmap where <paramref name="bitmapPoint"/>
        /// comes from</param>
        /// <returns></returns>
        private PointD ConvertBitmapPointToGraphPoint(Point bitmapPoint, Size bitmapSize)
        {
            int pointX = bitmapPoint.X;
            int pointY = bitmapPoint.Y;

            return new PointD(
                x: ((pointX - bitmapSize.Width / 2) * CurrentAxisLengths.X / bitmapSize.Width)
                + CurrentFocusPoint.X,

                y: (-(pointY - bitmapSize.Height / 2) * CurrentAxisLengths.Y / bitmapSize.Width)
                + CurrentFocusPoint.Y
            );
        }

        /// <summary>
        /// Calculates axis lengths.
        /// </summary>
        /// <param name="bitmapSize">The size of the original bitmap</param>
        /// <param name="rectangleSize">The size of the selected area of the bitmap</param>
        /// <returns></returns>
        private AxisLengths CalculateAxisLengths(Size bitmapSize, Size rectangleSize)
        {
            return new AxisLengths(
                xLength: CurrentAxisLengths.X / ((double)bitmapSize.Width / rectangleSize.Width),
                yLength: CurrentAxisLengths.Y / ((double)bitmapSize.Height / rectangleSize.Height)
            );
        }
    }
}
