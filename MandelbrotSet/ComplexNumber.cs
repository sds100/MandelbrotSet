namespace MandelbrotSet
{
    /// <summary>
    /// Represents a complex number.
    /// </summary>
    struct ComplexNumber
    {
        /// <summary>
        /// The real part of the complex number.
        /// For example: The 3 in (3 + 4i) is stored here.
        /// </summary>
        public double Re { get; }

        /// <summary>
        /// The coefficient of the imaginary part of the complex number.
        /// For example: 4i is represented as 4.
        /// </summary>
        public double Im { get; }

        /// <summary>
        /// Converts the Complex Number into a real number.
        /// </summary>
        public double Normal => Re * Re + Im * Im;

        public ComplexNumber(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }

        /// <summary>
        /// Add two complex numbers together.
        /// </summary>
        /// <returns>A complex number that is the sum of the two inputted complex numbers</returns>
        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re + y.Re, x.Im + y.Im);
        }

        /// <summary>
        /// Multiple two complex numbers together.
        /// </summary>
        /// <returns>
        /// A compelex number that is the product of the two inputted complex numbers
        /// </returns>
        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(
                re: x.Re * y.Re - x.Im * y.Im,
                im: x.Re * y.Im + x.Im * y.Re);
        }
    }
}
