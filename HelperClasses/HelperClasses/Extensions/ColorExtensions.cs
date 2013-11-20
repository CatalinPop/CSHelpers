using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HelperClasses.Extensions
{
    public static class ColorExtensions
    {
        public static Color GetProcent(this Color c, double ratio)
        {
            if(ratio>1 || ratio<0) return c;
            Color newcolor;
            newcolor = c;
            newcolor.A = (byte)(ratio * c.A);
            return newcolor;
        }
    }
}
