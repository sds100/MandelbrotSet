using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    /// <summary>
    /// Represents a particular portion of a plane.
    /// </summary>
    public class MandelPlane
    {
        /// <summary>
        /// Default length of one axis.
        /// For example: If the x axis goes from -4 to 4, it has a length of 8
        /// </summary>
        private const double DEFAULT_AXIS_LENGTH = 4;

        public static AxisLengths DEFAULT_AXIS_LENGTHS
            = new AxisLengths(DEFAULT_AXIS_LENGTH, DEFAULT_AXIS_LENGTH);

        /// <summary>
        /// The default point to draw the inital Mandelbrot Set around.
        /// </summary>
        public static PointD DEFAULT_FOCUS_POINT = new PointD(0, 0);

        public AxisLengths AxisLengths { get; set; }
        public PointD FocusPoint { get; set; }

        public double Width => AxisLengths.X;
        public double Height => AxisLengths.Y;

        public MandelPlane(AxisLengths axisLengths, PointD focusPoint)
        {
            AxisLengths = axisLengths;
            FocusPoint = focusPoint;
        }       
    }
}
