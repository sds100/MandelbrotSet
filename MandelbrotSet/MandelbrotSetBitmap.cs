using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    /// <summary>
    /// Where Mandelbrot Sets are rendered
    /// </summary>
    public static class MandelbrotSetBitmap
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
        /// <param name="imageInfo">The plane to base all calculations off.</param>
        /// <returns>A bitmap representation of a Mandelbrot Set</returns>
        public static Bitmap Create(Size bitmapSize, ImageInfo imageInfo, IProgressBar progressBar)
        {
            int width = bitmapSize.Width;
            int height = bitmapSize.Height;

            /* Bitmap objects can't be used across multiple tasks so a primitive 2D Color array
             * is used which will then be converted to a Bitmap object.
            */
            var bitmapRepresentation = new Color[width, height];

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

                        if (progressBar != null)
                        {
                            progressBar.OnProgress(CalculatePercent(height, thisRow));
                        }

                        //iterate through each column in the row.
                        for (int column = 0; column < bitmapSize.Width; column++)
                        {
                            /* since it is multi-threaded, nextRow maybe increased although
                             * the whole image has been drawn. */
                            if (thisRow >= bitmapSize.Height) break;

                            var pixel = CalculatePixel(
                                bitmapSize,
                                imageInfo,
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
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (bitmapRepresentation[column, row].A != 255)
                    {
                        bitmapRepresentation[column, row] = CalculatePixel(bitmapSize, imageInfo, new Point(column, row));
                    }
                }
            }

            //convert the 2D Color array into a Bitmap object.
            var bitmap = new Bitmap(width, height);

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

        public static Bitmap CreateNew(Size bitmapSize, ImageInfo imageInfo, IProgressBar progressBar)
        {
            Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

            IntPtr pointer = bitmapData.Scan0;

            int size = Math.Abs(bitmapData.Stride) * bitmap.Height;

            byte[] pixels = new byte[size];

            Marshal.Copy(pointer, pixels, 0, size);

            CalculatePixels(pixels, bitmapSize, imageInfo, 0, bitmapSize.Height);

            Marshal.Copy(pixels, 0, pointer, size);

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        public static async void ExportImageAsync(
         string path,
         Size bitmapSize,
         ImageInfo imageInfo,
         IExportImage iExportImage)
        {
            await Task.Run(() =>
            {
                var bitmap = Create(bitmapSize, imageInfo, iExportImage.ProgressBar);

                iExportImage.ProgressBar.OnSaveStart();

                bitmap.Save(path);

                bitmap.Dispose();

                iExportImage.OnExportFinished(path);
            });
        }

        private static void CalculatePixels(byte[] pixels, Size bitmapSize, ImageInfo imageInfo, int startRow, int endRow)
        {
            double axisWidth = imageInfo.AxisWidth;
            double planeHeight = imageInfo.AxisHeight;

            var focusPoint = imageInfo.FocusPoint;

            int bitmapWidth = bitmapSize.Width;
            int bitmapHeight = bitmapSize.Height;

            /* converts the pixel coordinate to the equivalent coordinate on the given 
             * portion of the complex plane. */

            for (int row = startRow; row < endRow; row++)
            {
                for (int column = 0; column < bitmapSize.Width; column++)
                {
                    // the real part of C will be the X coordinate
                    double c_real = ((column - bitmapWidth / 2) * axisWidth / bitmapWidth)
                        + focusPoint.X;

                    // the imaginary part of C will be the Y coordinate
                    double c_im = (-(row - bitmapHeight / 2) * planeHeight / bitmapWidth)
                        + focusPoint.Y;

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

                    Color color;

                    if (iteration < MAX_ITERATIONS)
                    {
                        color = ColorHelper.BLUE_BROWN[iteration % ColorHelper.BLUE_BROWN.Length];
                    }
                    else
                    {
                        color = Color.Black;
                    }

                    int i = ((row * bitmapWidth) + column) * 3;

                    pixels[i] = color.B;
                    pixels[i + 1] = color.G;
                    pixels[i + 2] = color.R;
                }
            }
        }

        /// <summary>
        /// Uses the Mandelbrot Set algorithm to determine what color a pixel should be.
        /// Look at the README if you don't understand this code.
        /// </summary>
        /// <param name="bitmapSize"></param>
        /// <param name="plane"></param>
        /// <param name="pixelCoords"></param>
        /// <param name="maxIterations"></param>
        /// <returns></returns>
        private static Color CalculatePixel(Size bitmapSize, ImageInfo plane, Point pixelCoords)
        {
            double planeWidth = plane.AxisWidth;
            double planeHeight = plane.AxisHeight;

            var planeCentre = plane.FocusPoint;

            int bitmapWidth = bitmapSize.Width;
            int bitmapHeight = bitmapSize.Height;

            /* converts the pixel coordinate to the equivalent coordinate on the given 
             * portion of the complex plane. */

            // the real part of C will be the X coordinate
            double c_real = ((pixelCoords.X - bitmapWidth / 2) * planeWidth / bitmapWidth)
                + planeCentre.X;

            // the imaginary part of C will be the Y coordinate
            double c_im = (-(pixelCoords.Y - bitmapHeight / 2) * planeHeight / bitmapWidth)
                + planeCentre.Y;

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

        private static int CalculatePercent(int totalRows, int currentRow)
        {
            return (int)Math.Round(((float)currentRow / totalRows) * 100);
        }
    }
}
