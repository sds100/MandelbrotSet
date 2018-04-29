using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    /// <summary>
    /// Where Mandelbrot Sets are drawn
    /// </summary>
    public static class MandelbrotSet
    {
        /// <summary>
        /// The maximum number of iterations for each pixel until it will be determined
        /// that it will escape to infinity.
        /// </summary>
        public const int MAX_ITERATIONS = 1000;

        /// <summary>
        /// The number of tasks that should run simultaneously to create an image.
        /// </summary>
        private static int THREAD_COUNT = Environment.ProcessorCount;

        /// <summary>
        /// Create a Mandelbrot Set.
        /// </summary>
        /// <param name="bitmapSize">The size the final bitmap should be</param>
        /// <param name="plane">The plane to base all calculations off.</param>
        /// <returns>A bitmap representation of a Mandelbrot Set</returns>
        public static Bitmap Create(Size bitmapSize, MandelPlane plane)
        {
            int bitmapWidth = bitmapSize.Width;
            int bitmapHeight = bitmapSize.Height;

            /* Bitmap objects can't be used across multiple tasks so a primitive 2D Color array
             * is used which will then be converted to a Bitmap object.
            */
            var bitmapRepresentation = new Color[bitmapWidth, bitmapHeight];

            //The next row which should be calculated
            int nextRow = 0;

            var taskList = new Task[THREAD_COUNT];

            for (int i = 0; i < THREAD_COUNT; i++)
            {
                taskList[i] = Task.Run(() =>
                {
                    //iterate through each row until all rows have been calculated.
                    while (nextRow < bitmapSize.Height)
                    {
                        int thisRow = nextRow;
                        nextRow++;

                        //iterate through each column in the row.
                        for (int column = 0; column < bitmapSize.Width; column++)
                        {
                            /* since it is multi-threaded, nextRow maybe increased although the whole image 
                             * has been drawn. */
                            if (thisRow >= bitmapSize.Height) break;

                            var pixel = CalculatePixel(
                                bitmapSize,
                                plane,
                                new Point(column, thisRow));

                            bitmapRepresentation[column, thisRow] = pixel;
                        }
                    }
                });
            }

            //wait for each task to complete.
            foreach (var task in taskList)
            {
                task.Wait();
            }

            //check if all rows have been calculated.
            for (int row = 0; row < bitmapHeight; row++)
            {
                for (int column = 0; column < bitmapWidth; column++)
                {
                    if (bitmapRepresentation[column, row].A != 255)
                    {
                        bitmapRepresentation[column, row] = CalculatePixel(bitmapSize, plane, new Point(column, row));
                    }
                }
            }

            //convert the 2D Color array into a Bitmap object.
            var bitmap = new Bitmap(bitmapWidth, bitmapHeight);

            for (int column = 0; column < bitmapSize.Width; column++)
            {
                for (int row = 0; row < bitmapSize.Height; row++)
                {
                    bitmap.SetPixel(column, row, bitmapRepresentation[column, row]);
                }
            }

            foreach (var task in taskList)
            {
                task.Dispose();
            }

            return bitmap;
        }

        /// <summary>
        /// Uses the Mandelbrot Set algorithm to determine what color a pixel should be.
        /// </summary>
        /// <param name="bitmapSize"></param>
        /// <param name="plane"></param>
        /// <param name="pixelCoords"></param>
        /// <param name="maxIterations"></param>
        /// <returns></returns>
        private static Color CalculatePixel(Size bitmapSize, MandelPlane plane, Point pixelCoords)
        {          
            double planeWidth = plane.Width;
            double planeHeight = plane.Height;

            var planeCentre = plane.FocusPoint;

            int bitmapWidth = bitmapSize.Width;
            int bitmapHeight = bitmapSize.Height;

            // converts the pixel coordinate to the equivalent coordinate on the specified plane.
            double c_real = ((pixelCoords.X - bitmapWidth / 2) * planeWidth / bitmapWidth)
                + planeCentre.X;

            double c_im = ((pixelCoords.Y - bitmapHeight / 2) * planeHeight / bitmapWidth)
                + planeCentre.Y;

            /* Look at .... to better understand what is happening. By using ComplexNumber classes
             * it is less daunting and easier to understand. */
            double z_real = 0;
            double z_im = 0;
            
            int iteration = 0;

            while (z_real * z_real + z_im * z_im < 4 && iteration < MAX_ITERATIONS)
            {
                double z_real_tmp = z_real * z_real - (z_im * z_im) + c_real;
                
                z_im = 2 * z_real * z_im + c_im;
                z_real = z_real_tmp;
                
                iteration++;
            }

            if (iteration < MAX_ITERATIONS)
            {
                var color = ColorHelper.BLUE_BROWN[iteration % ColorHelper.BLUE_BROWN.Length];
                
                return color;
            }
            else
            {
                return Color.Black;
            }
        }
    }
}
