using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    static class Help
    {
        //It is easier to understand the Math if a ComplexNumber class is created. Hower, it is slower.
        //public static Bitmap Create(Size size, MandelPlane plane)
        //{
        //    int maxIterations = 1000;

        //    int bitmapWidth = size.Width;
        //    int bitmapHeight = size.Height;

        //    decimal planeWidth = plane.Width;
        //    decimal planeHeight = plane.Height;
        //    var centrePoint = plane.CentrePoint;

        //    if (bitmapWidth <= 0 || bitmapHeight <= 0)
        //    {
        //        return null;
        //    }

        //    var bitmap = new Bitmap(bitmapWidth, bitmapHeight);

        //    int pixelCount = bitmapWidth * bitmapHeight;

        //    for (int column = 0; column < bitmapWidth; column++)
        //    {
        //        for (int row = 0; row < bitmapHeight; row++)
        //        {
        //            /* turns the image into an imaginary graph with -2 to 2 axis. the centre of the image is (0,0)
        //                "(column - width / 2) * axisLengths.X / width" gets the equivalent coordinate.                      
        //             */

        //            decimal c_real = ((column - bitmapWidth / 2) * planeWidth / bitmapWidth) + centrePoint.X;
        //            decimal c_im = ((row - bitmapHeight / 2) * planeHeight / bitmapWidth) + centrePoint.Y;

        //            decimal z_real = 0;
        //            decimal z_im = 0;

        //            var C = new ComplexNumber(c_real, c_im);
        //            var Z = new ComplexNumber(z_real, z_im);

        //            int iteration = 0;

        //            while (Z.Normal < 4 && iteration < maxIterations)
        //            {
        //                Z = Z * Z + C;
        //                iteration++;
        //            }

        //            if (iteration < maxIterations)
        //            {
        //                //var color = colors[iteration % colors.Length];
        //                //DrawPixel(bitmap, column, row, color);
        //            }
        //            else
        //            {
        //                //DrawPixel(bitmap, column, row, Color.Black);
        //            }
        //        }
        //    }

        //    return bitmap;
        //}
    }
}
