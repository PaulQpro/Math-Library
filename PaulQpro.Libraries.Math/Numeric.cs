using System;
using static System.Math;

namespace PaulQpro.Math
{
    public static class Numeric
    {
        /// <summary>
        /// Represents 8 bit numeric value using 8-units long Boolean array
        /// </summary>
        public sealed class UBin8
        {
            private bool[] Value { get; set; }
            public static UBin8 MaxValue { get; } = 255;

            static public explicit operator UBin8(bool[] value)
            {
                UBin8 bin = new();
                for (int i = 0; i < 8; i++)
                {
                    try { bin.Value[7 - i] = value[7 - i]; }
                    catch (IndexOutOfRangeException)
                    {
                        bin.Value[7 - i] = false;
                    }
                }
                bool[] a = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    a[i] = bin.Value[7 - i];
                }
                bin.Value = a;
                return bin;
            }
            static public explicit operator bool[](UBin8 value)
            {
                return value.Value;
            }
            static public implicit operator UBin8(byte value)
            {
                UBin8 bin = new();
                for (int i = 7; i >= 0; i--)
                {
                    bin.Value[i] = value % 2 == 1;
                    value /= 2;
                }
                return bin;
            }
            static public implicit operator byte(UBin8 value)
            {
                byte res = 0;
                bool[] req = ((bool[])value);
                for (int i = 7; i >= 0; i--)
                {
                    if (req[i])
                    {
                        res += (byte)Pow(2, 7 - i);
                    }
                }
                return res;
            }
            /// <summary>
            /// Represents a string value of object : "b--------"
            /// </summary>
            public override string ToString()
            {
                string result = "b";
                for (int i = 0; i < 8; i++)
                {
                    if (((bool[])this)[i]) result += "1";
                    else result += "0";
                }
                return result;
            }

            private UBin8() { Value = new bool[8]; }
        }
        /// <summary>
        /// Represents 4 bit numeric value using 4-units long Boolean array
        /// </summary>
        public sealed class UBin4
        {
            private bool[] Value { get; set; }
            public static UBin4 MaxValue { get; } = 15;

            static public explicit operator UBin4(bool[] value)
            {
                UBin4 bin = new();
                for (int i = 0; i < 4; i++)
                {
                    try { bin.Value[3 - i] = value[3 - i]; }
                    catch (IndexOutOfRangeException)
                    {
                        bin.Value[3 - i] = false;
                    }
                }
                bool[] a = new bool[4];
                for (int i = 0; i < 4; i++)
                {
                    a[i] = bin.Value[3 - i];
                }
                bin.Value = a;
                return bin;
            }
            static public explicit operator bool[](UBin4 value)
            {
                return value.Value;
            }
            static public implicit operator UBin4(byte value)
            {
                if (value > MaxValue) return MaxValue;
                UBin4 bin = new();
                for (int i = 3; i >= 0; i--)
                {
                    bin.Value[i] = value % 2 == 1;
                    value /= 2;
                }
                return bin;
            }
            static public implicit operator byte(UBin4 value)
            {
                byte res = 0;
                bool[] req = ((bool[])value);
                for (int i = 3; i >= 0; i--)
                {
                    if (req[i])
                    {
                        res += (byte)Pow(2, 3 - i);
                    }
                }
                return res;
            }
            /// <summary>
            /// Represents a string value of object : "b----"
            /// </summary>
            public override string ToString()
            {
                string result = "b";
                for (int i = 0; i < 4; i++)
                {
                    if (((bool[])this)[i]) result += "1";
                    else result += "0";
                }
                return result;
            }

            private UBin4() { Value = new bool[4]; }
        }
    }
}