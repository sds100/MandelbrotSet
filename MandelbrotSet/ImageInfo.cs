namespace MandelbrotSet
{
    /// <summary>
    /// Stores necessary information to recreate an image.
    /// </summary>
    public class ImageInfo
    {
        /// <summary>
        /// Default length of one axis.
        /// For example: If the x axis goes from -2 to 2, it has a length of 4
        /// The default is 4 because the entier Mandelbrot Set lies within a circle with radius of 2.
        /// </summary>
        private const double DEFAULT_AXIS_LENGTH = 4;

        public static AxisLengths DEFAULT_AXIS_LENGTHS
            = new AxisLengths(DEFAULT_AXIS_LENGTH, DEFAULT_AXIS_LENGTH);

        /// <summary>
        /// The point to draw the inital Mandelbrot Set around.
        /// </summary>
        public static PointD DEFAULT_FOCUS_POINT = new PointD(0, 0);

        public AxisLengths AxisLengths { get; set; }
        public PointD FocusPoint { get; set; }

        /// <summary>
        /// Axis width.
        /// </summary>
        public double AxisWidth => AxisLengths.X;

        /// <summary>
        /// Axis height.
        /// </summary>
        public double AxisHeight => AxisLengths.Y;

        public ImageInfo(AxisLengths axisLengths, PointD focusPoint)
        {
            AxisLengths = axisLengths;
            FocusPoint = focusPoint;
        }       
    }
}
