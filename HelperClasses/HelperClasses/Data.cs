using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public static class Data
    {
        public static byte[] Short2Bytes(short s)
        {
            byte b1 = (byte)(s >> 8);
            byte b2 = (byte)(s & 0xFF);
            return new byte[] { b1, b2 };
        }

        public static int Bytes2Int32(byte b1, byte b2, byte b3, byte b4)
        {
            return (b1 << 24) + (b2 << 16) + (b3 << 8) + b4;
        }

        public static short Bytes2Short(byte b1, byte b2)
        {
            return (short)((b1 << 8) + b2);
        }

        public static short[] ByteArrayToShortArray(byte[] array)
        {
            int j = 0;
            short[] words = new short[array.Length / 2];
            for (int i = 0; i < array.Length; i += 2)
            {
                words[j] = Bytes2Short(array[i], array[i + 1]);
                j++;
            }

            return words;
        }

        public static double Scale(int value, double sl, double sh, double usl, double ush)
        {
            double sr = sh - sl;
            double usr = ush - usl;
            double p = sr / usr;
            double result = sl + value * p;
            return sl + value * (sh - sl) / (ush - usl);
        }

    }
}
