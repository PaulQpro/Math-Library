using System;
using static System.Math;

namespace PaulQpro.Math
{
    public sealed class UBin8
    {
        private bool[] Value { get; set; }
        
        static public explicit operator UBin8 (bool[] value)
        {
            UBin8 bin = new();
            for(int i = 0; i < 8; i++)
            {
                try { bin.Value[7 - i] = value[7 - i]; }
                catch (IndexOutOfRangeException)
                {
                    bin.Value[7 - i] = false;
                }
            }
            bool[] a = new bool[8];
            for(int i = 0; i < 8; i++)
            {
                a[i] = bin.Value[7 - i];
            }
            bin.Value = a;
            return bin;
        }
        static public explicit operator bool[] (UBin8 value)
        {
            return value.Value;
        }
        static public explicit operator string (UBin8 value)
        {
            return value.ToString();
        }
        static public implicit operator UBin8 (byte value)
        {
            UBin8 bin = new();
            for (int i = 7; i >= 0; i--)
            {
                bin.Value[i] = value % 2 == 1;
                value /= 2;
            }
            return bin;
        }
        static public implicit operator byte (UBin8 value)
        {
            byte res = 0;
            bool[] req = ((bool[])value);
            for (int i = 7; i >= 0; i--)
            {
                if (req[i])
                {
                    res += (byte)Pow(2,7-i);
                }
            }
            return res;
        }

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
}