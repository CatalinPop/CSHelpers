using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HelperClasses
{
    public static class ColorTools
    {
        public static Color String2ColorARGB(string s)
        {
            byte A, R, G, B;
            A = Convert.ToByte(s.Substring(1, 2), 16);
            R = Convert.ToByte(s.Substring(3, 2), 16);
            G = Convert.ToByte(s.Substring(5, 2), 16);
            B = Convert.ToByte(s.Substring(7, 2), 16);

            return Color.FromArgb(A, R, G, B);
        }

        public static SolidColorBrush String2Brush(string s)
        {
            byte A, R, G, B;
            A = Convert.ToByte(s.Substring(1, 2), 16);
            R = Convert.ToByte(s.Substring(3, 2), 16);
            G = Convert.ToByte(s.Substring(5, 2), 16);
            B = Convert.ToByte(s.Substring(7, 2), 16);

            Color c = Color.FromArgb(A, R, G, B);
            SolidColorBrush b = new SolidColorBrush(c);

            return b;
        }
    }
}
