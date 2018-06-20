namespace MandelbrotSet
{
    /// <summary>
    /// Represents a pair of coordinates as Doubles.
    /// </summary>
    public struct PointD
    {
        public double X { get; }
        public double Y { get; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
