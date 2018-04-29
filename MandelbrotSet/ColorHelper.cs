using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public static class ColorHelper
    {
        public static Color[] BLUE_BROWN = new List<Color>
            {
                Color.FromArgb(66, 30, 15),
                Color.FromArgb(25, 7, 26),
                Color.FromArgb(9, 1, 47),
                Color.FromArgb(4, 4, 73),
                Color.FromArgb(0, 7, 100),
                Color.FromArgb(12, 44, 138),
                Color.FromArgb(24, 82, 177),
                Color.FromArgb(57, 125, 209),
                Color.FromArgb(134, 181, 229),
                Color.FromArgb(211, 236, 248),
                Color.FromArgb(241,233,191),
                Color.FromArgb(248, 201, 95),
                Color.FromArgb(255, 170, 0),
                Color.FromArgb(204, 128, 0),
                Color.FromArgb(153, 87, 0),
                Color.FromArgb(106, 52, 3)
            }.ToArray();

        public static Color[] CreateGradient(Color startColor, Color endColor, int steps)
        {
            var colorArray = new Color[steps];

            int stepR = ((endColor.R - startColor.R) / (steps - 1));
            int stepG = ((endColor.G - startColor.G) / (steps - 1));
            int stepB = ((endColor.B - startColor.B) / (steps - 1));

            for (int i = 0; i < steps; i++)
            {
                colorArray[i] = Color.FromArgb(startColor.R + (stepR * i),
                                            startColor.G + (stepG * i),
                                            startColor.B + (stepB * i));
            }

            return colorArray;
        }

        public static Color HSVToRGB(float hue, float saturation, float value)
        {
            //the hue must be between 0 and 360.
            while (hue < 0)
            {
                hue += 360;
            }

            while (hue >= 360)
            {
                hue -= 360;
            }

            double R, G, B;

            if (value <= 0)
            {
                R = G = B = 0;
            }
            else if (saturation <= 0)
            {
                R = G = B = value;
            }
            else
            {
                double hf = hue / 60.0;

                int i = (int)Math.Floor(hf);

                double f = hf - i;
                double pv = value * (1 - saturation);
                double qv = value * (1 - saturation * f);
                double tv = value * (1 - saturation * (1 - f));

                switch (i)
                {
                    case 0:
                        R = value;
                        G = tv;
                        B = pv;
                        break;

                    case 1:
                        R = qv;
                        G = value;
                        B = pv;
                        break;

                    case 2:
                        R = pv;
                        G = value;
                        B = tv;
                        break;

                    case 3:
                        R = pv;
                        G = qv;
                        B = value;
                        break;

                    case 4:
                        R = tv;
                        G = pv;
                        B = value;
                        break;
                        
                    case 5:
                        R = value;
                        G = pv;
                        B = qv;
                        break;
                        
                    case 6:
                        R = value;
                        G = tv;
                        B = pv;
                        break;

                    case -1:
                        R = value;
                        G = pv;
                        B = qv;
                        break;

                    default:
                        R = G = B = value;
                        break;
                }
            }

            int r = Clamp((int)(R * 255.0));
            int g = Clamp((int)(G * 255.0));
            int b = Clamp((int)(B * 255.0));

            return Color.FromArgb(r, g, b);
        }

        private static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}
