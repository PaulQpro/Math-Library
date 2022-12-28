using System;
#pragma warning disable IDE1006
namespace PaulQpro.Math
{
    static public partial class Linear
    {
        public abstract class BaseVector : BaseMatrix
        {
            public override int[] Dimensions { get; } = new int[1];
            protected virtual double[] VectorValue { get; set; }
            public override string ToString()
            {
                if (IsZero)
                {
                    SetZero();
                }
                string returnValue = "{";
                foreach (var value in VectorValue){
                    returnValue += value.ToString() + ", ";
                }
                returnValue = returnValue.TrimEnd(new char[] { ',', ' ' })+"}";
                return returnValue;
            }
            public override void SetZero()
            {
                for (int ind = 0; ind < Dimensions[0]; ind++)
                {
                    VectorValue[ind] = 0;
                }
            }
            protected BaseVector()
            {
                Dimensions[0] = 0;
                VectorValue = Array.Empty<double>();
                IsZero = true;
            }
        }
        public class Vector : BaseVector
        {
            public Vector(int dimensions, double[] vectorValue)
            {
                Dimensions[0] = dimensions;
                int vv = 0;
                foreach (var item in vectorValue)
                {
                    vv++;
                }
                if (dimensions == 0 || vv == 0)
                {
                    IsZero = true;
                    SetZero();
                }
                if (vectorValue.Length != dimensions)
                {
                    VectorValue = new double[dimensions];
                    for (int i = 0; i < dimensions; i++)
                    {
                        try
                        {
                            VectorValue[i] = vectorValue[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            VectorValue[i] = 0;
                        }
                    }
                }
                else VectorValue = vectorValue;
            }
            public Vector(double[] vectorValue)
            {
                Dimensions[0] = vectorValue.Length;
                VectorValue = vectorValue;
                int vv = 0;
                foreach (var item in vectorValue)
                {
                    vv++;
                }
                if (vectorValue.Length == 0 || vv == 0)
                {
                    IsZero = true;
                    SetZero();
                }
            }
        }
        public class Vector2D : BaseVector
        {
            public override int[] Dimensions { get; } = new int[1] { 2 };
            public double x { get; protected set; }
            public double y { get; protected set; }
            public Vector2D(double[] vectorValue)
            {
                int vv = 0;
                foreach (var item in vectorValue)
                {
                    vv++;
                }
                if (vectorValue.Length == 0 || vv == 0)
                {
                    IsZero = true;
                    SetZero();
                }
                if (vectorValue.Length != vectorValue.Length)
                {
                    VectorValue = new double[vectorValue.Length];
                    for (int i = 0; i < vectorValue.Length; i++)
                    {
                        try
                        {
                            VectorValue[i] = vectorValue[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            VectorValue[i] = 0;
                        }
                    }
                }
                else VectorValue = vectorValue;
                x = VectorValue[0];
                y = VectorValue[1];
            }
        }
        public class Vector3D : BaseVector
        {
            public override int[] Dimensions { get; } = new int[1] { 2 };
            public double x { get; protected set; }
            public double y { get; protected set; }
            public double z { get; protected set; }
            public Vector3D(double[] vectorValue)
            {
                VectorValue = vectorValue;
                int vv = 0;
                foreach (var item in vectorValue)
                {
                    vv++;
                }
                if (vectorValue.Length == 0 || vv == 0)
                {
                    IsZero = true;
                    SetZero();
                }
                if (vectorValue.Length != vectorValue.Length)
                {
                    VectorValue = new double[3];
                    for (int i = 0; i < vectorValue.Length; i++)
                    {
                        try
                        {
                            VectorValue[i] = vectorValue[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            VectorValue[i] = 0;
                        }
                    }
                }
                else VectorValue = vectorValue;
                x = VectorValue[0];
                y = VectorValue[1];
                z = VectorValue[2];
            }
        }
    }
}
#pragma warning restore IDE1006