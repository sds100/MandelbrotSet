namespace MandelbrotSet
{
    /// <summary>
    /// Stores the lengths of the X and Y axis'.
    /// <para>
    /// For example: If the X axis goes from -4 to 4, the length will be 8.
    /// </para>
    /// </summary>
    public struct AxisLengths
    {
        public double X { get; }
        public double Y { get; }

        public AxisLengths(double xLength, double yLength)
        {
            X = xLength;
            Y = yLength;
        }       
    }
}
