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
            static public Vector2D operator + (Vector2D a, Vector2D b)
            {
                return new(new double[2] { a.x + b.x, a.y + b.y });
            }
            static public Vector2D operator - (Vector2D a)
            {
                return new(new double[2] { -a.x, -a.y }); 
            }
            static public Vector2D operator - (Vector2D a, Vector2D b)
            {
                return new(new double[2] { a.x - b.x, a.y - b.y });
            }
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
                if (VectorValue.Length != vectorValue.Length)
                {
                    VectorValue = new double[2] { 0, 0 };
                    for (int i = 0; i < vectorValue.Length; i++)
                    {
                        try
                        {
                            VectorValue[i] = vectorValue[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            
                        }
                    }
                }
                else VectorValue = vectorValue;
                x = VectorValue[0];
                y = VectorValue[1];
            }
            public Vector2D(double x, double y)
            {
                VectorValue = new double[2] { x, y };
                this.x = x;
                this.y = y;
            }
        }
        public class Vector3D : BaseVector
        {
            public override int[] Dimensions { get; } = new int[1] { 2 };
            public double x { get; protected set; }
            public double y { get; protected set; }
            public double z { get; protected set; }
            static public Vector3D operator +(Vector3D a, Vector3D b)
            {
                return new(new double[3] { a.x + b.x, a.y + b.y, a.z + b.z });
            }
            static public Vector3D operator -(Vector3D a)
            {
                return new(new double[3] { -a.x, -a.y, -a.z });
            }
            static public Vector3D operator -(Vector3D a, Vector3D b)
            {
                return new(new double[3] { a.x - b.x, a.y - b.y, a.z - b.z });
            }
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
                if (VectorValue.Length != vectorValue.Length)
                {
                    VectorValue = new double[3] { 0, 0, 0 };
                    for (int i = 0; i < vectorValue.Length; i++)
                    {
                        try
                        {
                            VectorValue[i] = vectorValue[i];
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                else VectorValue = vectorValue;
                x = VectorValue[0];
                y = VectorValue[1];
                z = VectorValue[2];
            }
            public Vector3D(double x, double y, double z)
            {
                VectorValue = new double[3] { x, y, z };
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    }
}
#pragma warning restore IDE1006