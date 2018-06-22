using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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
        private static int CORE_COUNT = Environment.ProcessorCount;

        /// <summary>
        /// How many colors each pixel represents. e.g ARGB is 4.
        /// </summary>
        private static int COLORS_PER_PIXEL = 4;

        /// <summary>
        /// The interval at which the percentage progress should be calculated
        /// </summary>
        private static int REPORT_ROW_INTERVAL = 10;

        private static int CalculatedRows = 0;

        /// <summary>
        /// Render the Mandelbrot Set
        /// </summary>
        /// <param name="bitmapSize">The size of the Bitmap to create</param>
        /// <param name="imageInfo">The information required to render the desired portion of the Mandelbrot Set</param>
        /// <param name="progressBar">The <see cref="IProgressBar"/> to use.</param>
        /// <returns></returns>
        public static Bitmap Render(Size bitmapSize, ImageInfo imageInfo, IProgressBar progressBar, bool reportProgress)
        {
            var bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height, PixelFormat.Format32bppRgb);

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var pointer = bitmapData.Scan0;

            int size = Math.Abs(bitmapData.Stride) * bitmap.Height;

            byte[] pixels = new byte[size];

            Marshal.Copy(pointer, pixels, 0, size);

            var actions = CreateActions(pixels, bitmapSize, imageInfo, progressBar, reportProgress);

            Parallel.Invoke(actions);

            Marshal.Copy(pixels, 0, pointer, size);

            bitmap.UnlockBits(bitmapData);

            if (reportProgress)
            {
                progressBar.OnProgressFinish();
                CalculatedRows = 0;
            }

            return bitmap;
        }

        /// <summary>
        /// Overload for <see cref="Render(Size, ImageInfo, IProgressBar, bool)"/>.
        /// Use if a progress reporting isn't required
        /// </summary>
        public static Bitmap Render(Size bitmapSize, ImageInfo imageInfo)
        {
            return Render(bitmapSize, imageInfo, progressBar: null, reportProgress: false);
        }

        /// <summary>
        /// Export a portion of the Mandelbrot Set to a desired path.
        /// </summary>
        /// <param name="path">The path to the .png file.</param>
        /// <param name="bitmapSize">The size of the bitmap to create</param>
        public static async void ExportImageAsync(
         string path,
         Size bitmapSize,
         ImageInfo imageInfo,
         IExportImage iExportImage)
        {
            await Task.Run(() =>
            {
                var bitmap = Render(bitmapSize, imageInfo, iExportImage.ProgressBar, reportProgress: true);

                iExportImage.OnSaveStart();

                bitmap.Save(path);

                bitmap.Dispose();

                iExportImage.OnExportFinished(path);
            });
        }

        private static Action[] CreateActions(
            byte[] pixels,
            Size bitmapSize,
            ImageInfo imageInfo,
            IProgressBar progressBar,
            bool reportProgress)
        {
            var actions = new List<Action>();

            int totalRows = bitmapSize.Height;
            int chunkSize = totalRows / CORE_COUNT;

            for (int i = 0; i < CORE_COUNT; i++)
            {
                int startRow;

                if (i == 0)
                {
                    startRow = 0;
                }
                else
                {
                    startRow = (chunkSize * i);
                }

                int endRow = chunkSize * (i + 1);

                actions.Add(() => CalculatePixels(
                    pixels,
                    bitmapSize,
                    imageInfo,
                    startRow,
                    endRow,
                    totalRows,
                    progressBar,
                    reportProgress));
            }

            /* If there are some left over rows which won't be rendered because the number of rows won't necessarily
             * be divisible by the core count */
            if (chunkSize * CORE_COUNT < bitmapSize.Height)
            {
                int startRow = (chunkSize * CORE_COUNT);
                int endRow = bitmapSize.Height;

                actions.Add(() => CalculatePixels(
                    pixels,
                    bitmapSize,
                    imageInfo,
                    startRow,
                    endRow,
                    totalRows,
                    progressBar,
                    reportProgress));
            }

            return actions.ToArray();
        }

        private static void OnCalculatedRow(IProgressBar progressBar, int totalRows)
        {
            CalculatedRows += REPORT_ROW_INTERVAL;
            progressBar.OnProgress(CalculatePercent(totalRows, CalculatedRows));
        }

        private static void CalculatePixels(
            byte[] pixels,
            Size bitmapSize,
            ImageInfo imageInfo,
            int startRow,
            int endRow,
            int totalRows,
            IProgressBar progressBar,
            bool reportProgress)
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

                    int i = ((row * bitmapWidth) + column) * COLORS_PER_PIXEL;

                    pixels[i] = color.B;
                    pixels[i + 1] = color.G;
                    pixels[i + 2] = color.R;
                }

                if (reportProgress && row % REPORT_ROW_INTERVAL == 0)
                {
                    OnCalculatedRow(progressBar, totalRows);
                }
            }
        }

        private static int CalculatePercent(int totalRows, int currentRow)
        {
            int percent = (int)Math.Round(((float)currentRow / totalRows) * 100);

            return percent;
        }
    }
}
