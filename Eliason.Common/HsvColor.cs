using System;
using System.Drawing;

namespace Eliason.Common
{
    /// <summary>
    ///   Adapted from: 
    ///   "A Primer on Building a Color Picker User Control with GDI+ in Visual Basic .NET or C#"
    ///   http://www.msdnaa.net/Resources/display.aspx?ResID=2460
    /// </summary>
    public struct HsvColor
    {
        public int Hue; // 0-360
        public int Saturation; // 0-100
        public int Value; // 0-100

        public HsvColor(int hue, int saturation, int value)
        {
            if (hue < 0 || hue > 360)
            {
                throw new ArgumentOutOfRangeException("hue", "must be in the range [0, 360]");
            }

            if (saturation < 0 || saturation > 100)
            {
                throw new ArgumentOutOfRangeException("saturation", "must be in the range [0, 100]");
            }

            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("value", "must be in the range [0, 100]");
            }

            this.Hue = hue;
            this.Saturation = saturation;
            this.Value = value;
        }

        public static bool operator ==(HsvColor lhs, HsvColor rhs)
        {
            return (lhs.Hue == rhs.Hue) &&
                   (lhs.Saturation == rhs.Saturation) &&
                   (lhs.Value == rhs.Value);
        }

        public static bool operator !=(HsvColor lhs, HsvColor rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            return this == (HsvColor) obj;
        }

        public override int GetHashCode()
        {
            return (this.Hue + (this.Saturation << 8) + (this.Value << 16)).GetHashCode();
        }

        public static HsvColor FromColor(Color color)
        {
            var rgb = new RgbColor(color.R, color.G, color.B);
            return rgb.ToHsv();
        }

        public Color ToColor()
        {
            var rgb = this.ToRgb();
            return Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue);
        }

        public RgbColor ToRgb()
        {
            // HsvColor contains values scaled as in the color wheel:

            double r = 0;
            double g = 0;
            double b = 0;

            // Scale Hue to be between 0 and 360. Saturation
            // and value scale to be between 0 and 1.
            var h = (double) this.Hue%360;
            var s = (double) this.Saturation/100;
            var v = (double) this.Value/100;

            if (s == 0)
            {
                // If s is 0, all colors are the same.
                // This is some flavor of gray.
                r = v;
                g = v;
                b = v;
            }
            else
            {
                // The color wheel consists of 6 sectors.
                // Figure out which sector you're in.
                var sectorPos = h/60;
                var sectorNumber = (int) (Math.Floor(sectorPos));

                // get the fractional part of the sector.
                // That is, how many degrees into the sector
                // are you?
                var fractionalSector = sectorPos - sectorNumber;

                // Calculate values for the three axes
                // of the color. 
                var p = v*(1 - s);
                var q = v*(1 - (s*fractionalSector));
                var t = v*(1 - (s*(1 - fractionalSector)));

                // Assign the fractional colors to r, g, and b
                // based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }
            }
            // return an RgbColor structure, with values scaled
            // to be between 0 and 255.
            return new RgbColor((int) (r*255), (int) (g*255), (int) (b*255));
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", this.Hue, this.Saturation, this.Value);
        }
    }
}